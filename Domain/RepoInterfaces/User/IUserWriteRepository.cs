using Domain.Interfaces;

namespace Domain.RepoInterfaces.User;

public interface IUserWriteRepository : IWriteRepository<Entities.User.User>
{
    public Task<bool> UsernameExistsAsync(string username);
    Task<bool> TelegramIdExistsAsync(string telegramId, CancellationToken ct = default);
}