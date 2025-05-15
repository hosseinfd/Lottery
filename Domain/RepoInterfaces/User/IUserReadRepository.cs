using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.User;

public interface IUserReadRepository : IReadRepository<UserDao>
{
    Task<UserDao?> GetByTelegramIdAsync(string telegramId);
}