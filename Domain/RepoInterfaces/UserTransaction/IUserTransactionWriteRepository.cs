using Domain.Entities.UserTransaction;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserTransaction;

public interface IUserTransactionWriteRepository : IWriteRepository<TransactionDao>
{
    Task<bool> HasRewardForScenarioAsync(Guid userId, Guid scenarioId, CancellationToken ct = default);
}