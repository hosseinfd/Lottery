using AutoMapper;
using Domain.Entities.UserBalance;
using Domain.RepoInterfaces.UserBalance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserBalance;

public class UserBalanceReadRepository(AppDbContext context)
    : ReadRepository<UserBalanceDao>(context), IUserBalanceReadRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<UserBalanceDao>> GetUserBalancesAsync(Guid userId) =>
        await _context.UserBalances.Where(b => b.UserId == userId).Include(b => b.CurrencyDao).ToListAsync();
}