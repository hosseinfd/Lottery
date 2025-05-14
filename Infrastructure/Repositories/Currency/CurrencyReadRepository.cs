using AutoMapper;
using Domain.RepoInterfaces.Currency;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Currency;

public class CurrencyReadRepository : ReadRepository<Domain.Currency.Currency>,ICurrencyReadRepository
{
    private readonly AppDbContext _context;
    public CurrencyReadRepository(AppDbContext context, IMapper mapper) : base(context,mapper)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Currency.Currency>> GetAllAsync() => await _context.Currencies.ToListAsync();
    public async Task<Domain.Currency.Currency?> GetByIdAsync(Guid currencyId)
    {
        return await _context.Currencies
            .Where(q => q.CurrencyId == currencyId)
            .Select(q => q)
            .FirstOrDefaultAsync();
    }
}