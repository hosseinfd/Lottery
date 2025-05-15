using AutoMapper;
using Domain.Entities.User;
using Domain.Interfaces;
using Domain.RepoInterfaces.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.User;

public class UserReadRepository(AppDbContext context) : ReadRepository<UserDao>(context), IUserReadRepository
{
    public async Task<UserDao?> GetByTelegramIdAsync(string telegramId) =>
        await context.Users.FirstOrDefaultAsync(u => u.TelegramId == telegramId);

    // public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    // {
    //     return await ProjectToDto<UserDao, UserDto>(
    //             _context.Users.Where(u => u.Id == id))
    //         .FirstOrDefaultAsync(ct);
    // }
}