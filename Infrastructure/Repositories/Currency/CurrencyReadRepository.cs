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

}