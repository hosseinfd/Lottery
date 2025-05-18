using AutoMapper;
using Domain.RepoInterfaces.Currency;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Currency;

public class CurrencyReadRepository : ReadRepository<Domain.Entities.Currency.CurrencyDao>,ICurrencyReadRepository
{
    private readonly AppDbContext _context;
    public CurrencyReadRepository(AppDbContext context, IMapper mapper) : base(context,mapper)
    {
        _context = context;
    }

}