using Domain.Entities.UserBalance;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserBalance;

public interface IUserBalanceReadRepository : IReadRepository<UserBalanceDao>
{
    public Task<IEnumerable<UserBalanceDao>> GetUserBalancesAsync(Guid userId);
}