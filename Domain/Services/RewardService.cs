// using Domain.Event;
// using Domain.Exceptions;
// using Domain.Interfaces;
// using Domain.RepoInterfaces;
// using Domain.RepoInterfaces.Scenario;
// using Domain.RepoInterfaces.UserBalance;
// using Domain.RepoInterfaces.UserTransaction;
// using Domain.ServiceInterfaces;
// using Google.Protobuf.Reflection;
//
// namespace Domain.Services;
//
// // Domain/Services/RewardService.cs
// public class RewardService : IRewardService
// {
//     private readonly IScenarioReadRepository _scenarioReadRepo;
//     private readonly IUserBalanceWriteRepository _balanceCommandRepo;
//     private readonly IUserTransactionWriteRepository _transactionCommandRepo;
//     private readonly IUnitOfWork _uow;
//
//     public RewardService(
//         IScenarioReadRepository scenarioReadRepo,
//         IUserBalanceWriteRepository balanceCommandRepo,
//         IUserTransactionWriteRepository transactionCommandRepo,
//         IUnitOfWork uow)
//     {
//         _scenarioReadRepo = scenarioReadRepo;
//         _balanceCommandRepo = balanceCommandRepo;
//         _transactionCommandRepo = transactionCommandRepo;
//         _uow = uow;
//     }
//
//     public async Task<RewardResult> ProcessScenarioCompletion(
//         Guid userId, 
//         Guid scenarioId,
//         Dictionary<string, object> verificationData)
//     {
//         await _uow.BeginTransactionAsync();
//         
//         try
//         {
//             // 1. Get scenario with reward details
//             var scenario = await _scenarioReadRepo.GetByIdAsync(scenarioId);
//             if (scenario == null)
//                 throw new NotFoundException(new ValidationItem(null,"Scenario not found","3001"));
//
//             // 2. Check if already rewarded
//             if (await _transactionCommandRepo.HasRewardForScenarioAsync(userId, scenarioId))
//                 throw new NotFoundException(new ValidationItem(null,"Already rewarded for this scenario","3002"));
//
//             // 3. Verify scenario completion
//             if (!await VerifyScenarioCompletion(userId, scenario, verificationData))
//                 throw new NotFoundException(new ValidationItem(null,"Scenario requirements not met","3003"));
//
//             // 4. Process reward
//             var balance = await _balanceCommandRepo.GetOrCreateAsync(userId, scenario.RewardCurrencyId);
//             balance.Credit(scenario.RewardValue);
//             _balanceCommandRepo.Update(balance);
//
//             var transaction = new UserTransaction.UserTransaction(
//                 userId,
//                 scenario.RewardCurrencyId,
//                 scenario.RewardValue,
//                 TransactionType.EventReward,
//                 $"Reward for completing scenario: {scenario.Name}",
//                 scenario.EventId,
//                 scenarioId);
//
//             await _transactionCommandRepo.AddAsync(transaction);
//             await _uow.CommitAsync();
//
//             return new RewardResult(
//                 scenario.RewardValue,
//                 scenario.RewardCurrency.Symbol,
//                 balance.Amount);
//         }
//         catch
//         {
//             await _uow.RollbackAsync();
//             throw;
//         }
//     }
//
//     
//     private async Task<bool> VerifyScenarioCompletion(
//         Guid userId, 
//         Scenario scenario,
//         Dictionary<string, object> verificationData)
//     {
//         switch (scenario.ConditionType)
//         {
//             case ConditionType.LocationCheckIn:
//                 return await VerifyLocationCheckIn(scenario, verificationData);
//             
//             case ConditionType.QrCodeScan:
//                 return VerifyQrCodeScan(scenario, verificationData);
//             
//             case ConditionType.TimeSpent:
//                 return await VerifyTimeSpent(userId, scenario, verificationData);
//             
//             case ConditionType.SocialMediaShare:
//                 return VerifySocialMediaShare(verificationData);
//             
//             default:
//                 throw new InvalidOperationException($"Unsupported condition type: {scenario.ConditionType}");
//         }
//     }
//     
//     private async Task<bool> VerifyLocationCheckIn(
//         Scenario scenario,
//         Dictionary<string, object> verificationData)
//     {
//         if (!verificationData.TryGetValue("latitude", out var latObj) ||
//             !verificationData.TryGetValue("longitude", out var lonObj))
//             return false;
//
//         var userLocation = new SourceCodeInfo.Types.Location(
//             Convert.ToDouble(latObj),
//             Convert.ToDouble(lonObj));
//
//         return await _locationService.IsWithinRadius(
//             userLocation,
//             scenario.RequiredLocation,
//             scenario.AllowedRadiusInMeters);
//     }
//
//     private bool VerifyQrCodeScan(
//         Scenario scenario,
//         Dictionary<string, object> verificationData)
//     {
//         return verificationData.TryGetValue("qrCode", out var qrCode) &&
//                qrCode?.ToString() == scenario.RequiredQrCode;
//     }
//     
//     // Domain/Services/RewardService.cs (partial)
//     public async Task<RewardResult> ProcessScenarioReward(
//         Guid userId, 
//         Guid scenarioId,
//         Dictionary<string, object> verificationData)
//     {
//         await _unitOfWork.BeginTransactionAsync();
//     
//         try
//         {
//             var scenario = await _scenarioReadRepo.GetByIdAsync(scenarioId)
//                            ?? throw new NotFoundException("Scenario not found");
//
//             if (await _transactionCommandRepo.HasRewardForScenarioAsync(userId, scenarioId))
//                 throw new DomainException("Already rewarded for this scenario");
//
//             if (!await VerifyScenarioCompletion(userId, scenario, verificationData))
//                 throw new DomainException("Scenario requirements not met");
//
//             // Process balance update
//             var balance = await _balanceCommandRepo.GetOrCreateAsync(userId, scenario.RewardCurrencyId);
//             balance.Credit(scenario.RewardValue);
//             _balanceCommandRepo.Update(balance);
//
//             // Create transaction record
//             var transaction = new Transaction(
//                 userId,
//                 scenario.RewardCurrencyId,
//                 scenario.RewardValue,
//                 TransactionType.EventReward,
//                 $"Reward for completing: {scenario.Name}",
//                 scenario.EventId,
//                 scenarioId);
//
//             await _transactionCommandRepo.AddAsync(transaction);
//             await _unitOfWork.CommitAsync();
//
//             return new RewardResult(
//                 scenario.RewardValue,
//                 scenario.RewardCurrency.Symbol,
//                 balance.Amount,
//                 transaction.Id);
//         }
//         catch
//         {
//             await _unitOfWork.RollbackAsync();
//             throw;
//         }
//     }
//
//     // ... verification methods remain the same
// }