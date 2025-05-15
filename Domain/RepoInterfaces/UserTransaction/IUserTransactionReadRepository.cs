using Domain.Entities.UserTransaction;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserTransaction;

public interface IUserTransactionReadRepository : IReadRepository<TransactionDao>
{
    public Task<IEnumerable<TransactionDao>> GetByUserIdAsync(Guid userId);
}