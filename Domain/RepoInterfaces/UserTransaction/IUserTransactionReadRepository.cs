using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserTransaction;

public interface IUserTransactionReadRepository : IReadRepository<Entities.UserTransaction.UserTransaction>
{
    public Task<IEnumerable<Entities.UserTransaction.UserTransaction>> GetByUserIdAsync(Guid userId);
}