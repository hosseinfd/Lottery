using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserTransaction;

public interface IUserTransactionReadRepository : IReadRepository<Domain.UserTransaction.UserTransaction>
{
    public Task<IEnumerable<Domain.UserTransaction.UserTransaction>> GetByUserIdAsync(Guid userId);
}