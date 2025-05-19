using Domain.Entities.Currency;
using Domain.RepoInterfaces.Currency;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Currency;

public class CurrencyWriteRepository : WriteRepository<CurrencyDao>, ICurrencyWriteRepository
{
    private readonly AppDbContext _context;

    public CurrencyWriteRepository(AppDbContext context) : base(context) => _context = context;
}