using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserTransaction;

public interface IUserTransactionWriteRepository : IWriteRepository<Entities.UserTransaction.UserTransaction>
{
    Task<bool> HasRewardForScenarioAsync(Guid userId, Guid scenarioId, CancellationToken ct = default);
}