using AutoMapper;
using Domain.RepoInterfaces.UserBalance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserBalance;

public class UserBalanceReadRepository : ReadRepository<Domain.UserBalance.UserBalance>, IUserBalanceReadRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserBalanceReadRepository(AppDbContext context, IMapper mapper) :base(context,mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Domain.UserBalance.UserBalance>> GetUserBalancesAsync(Guid userId) =>
        await _context.UserBalances.Where(b => b.UserId == userId).Include(b => b.Currency).ToListAsync();
}