using Domain.RepoInterfaces.Winner;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Winner;

public class WinnerWriteRepository : WriteRepository<Domain.Entities.Winner.WinnerDao>, IWinnerWriteRepository
{
    private readonly AppDbContext _context;

    public WinnerWriteRepository(AppDbContext context) : base(context) => _context = context;
}