using Domain.RepoInterfaces.User;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.User;

public class UserWriteRepository : WriteRepository<Domain.Entities.User.UserDao>,IUserWriteRepository
{
    private readonly AppDbContext _context;

    public UserWriteRepository(AppDbContext context) : base(context) => _context = context;

    public async Task<bool> UsernameExistsAsync(string username)
    {
        var isExist = await _context.Users
            .AnyAsync(q => q.Username == username);
        return isExist;
    }

    public async Task<bool> TelegramIdExistsAsync(string telegramId, CancellationToken ct = default)
    {
        return await _context.Users.AnyAsync(q => q.TelegramId == telegramId, ct);
    }
}