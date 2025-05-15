using AutoMapper;
using Domain.Entities.Currency;
using Domain.RepoInterfaces.Currency;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Currency;

public class CurrencyReadRepository : ReadRepository<CurrencyDao>, ICurrencyReadRepository
{
    private readonly AppDbContext _context;

    public CurrencyReadRepository(AppDbContext context, IMapper mapper) : base(context)
    {
        _context = context;
    }
}