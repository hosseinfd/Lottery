using Domain.Entities.UserBalance;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.UserBalance;

public interface IUserBalanceWriteRepository : IWriteRepository<UserBalanceDao>
{
}