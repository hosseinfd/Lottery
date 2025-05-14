using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserBalance;

public interface IUserBalanceReadRepository : IReadRepository<Domain.UserBalance.UserBalance>
{
    public Task<IEnumerable<Domain.UserBalance.UserBalance>> GetUserBalancesAsync(Guid userId);
}