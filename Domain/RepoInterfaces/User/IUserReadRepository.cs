using Domain.Interfaces;

namespace Domain.RepoInterfaces.User;

public interface IUserReadRepository : IReadRepository<Entities.User.UserDao>
{
    Task<Entities.User.UserDao?> GetByTelegramIdAsync(string telegramId);
}