using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserBalance;

public interface IUserBalanceReadRepository : IReadRepository<Entities.UserBalance.UserBalanceDao>
{
    public Task<IEnumerable<Entities.UserBalance.UserBalanceDao>> GetUserBalancesAsync(Guid userId);
}