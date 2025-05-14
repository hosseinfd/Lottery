using Domain.Interfaces;

namespace Domain.RepoInterfaces.User;

public interface IUserReadRepository : IReadRepository<Domain.User.User>
{
    Task<Domain.User.User?> GetByTelegramIdAsync(string telegramId);
}