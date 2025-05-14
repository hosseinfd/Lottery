using AutoMapper;
using Domain.Interfaces;
using Domain.RepoInterfaces.User;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.User;

public class UserReadRepository : ReadRepository<Domain.User.User>, IUserReadRepository
{
    private readonly AppDbContext _context;

    public UserReadRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
    }

    public async Task<Domain.User.User?> GetByTelegramIdAsync(string telegramId) =>
        await _context.Users.FirstOrDefaultAsync(u => u.TelegramId == telegramId);

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await ProjectToDto<Domain.User.User, UserDto>(
                _context.Users.Where(u => u.UserId == id))
            .FirstOrDefaultAsync(ct);
    }
}