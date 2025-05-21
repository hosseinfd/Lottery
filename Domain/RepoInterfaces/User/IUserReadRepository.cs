using Domain.Interfaces;

namespace Domain.RepoInterfaces.User;

public interface IUserReadRepository : IReadRepository<Entities.User.User>
{
    Task<Entities.User.User?> GetByTelegramIdAsync(string telegramId);
}