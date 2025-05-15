using Domain.Entities.Winner;
using Domain.RepoInterfaces.Winner;

namespace Infrastructure.Repositories.Winner;

public class WinnerWriteRepository : WriteRepository<WinnerDao>, IWinnerWriteRepository
{
    private readonly AppDbContext _context;

    public WinnerWriteRepository(AppDbContext context) : base(context) => _context = context;
}