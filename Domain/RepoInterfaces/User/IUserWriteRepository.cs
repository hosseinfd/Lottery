using Domain.Interfaces;

namespace Domain.RepoInterfaces.User;

public interface IUserWriteRepository : IWriteRepository<Entities.User.UserDao>
{
    public Task<bool> UsernameExistsAsync(string username);
    Task<bool> TelegramIdExistsAsync(string telegramId, CancellationToken ct = default);
}