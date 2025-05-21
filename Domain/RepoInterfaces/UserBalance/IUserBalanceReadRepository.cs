using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserBalance;

public interface IUserBalanceReadRepository : IReadRepository<Entities.UserBalance.UserBalance>
{
    public Task<IEnumerable<Entities.UserBalance.UserBalance>> GetUserBalancesAsync(Guid userId);
}