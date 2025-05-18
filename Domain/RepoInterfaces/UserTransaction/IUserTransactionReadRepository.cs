using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserTransaction;

public interface IUserTransactionReadRepository : IReadRepository<Entities.UserTransaction.UserTransactionDao>
{
    public Task<IEnumerable<Entities.UserTransaction.UserTransactionDao>> GetByUserIdAsync(Guid userId);
}