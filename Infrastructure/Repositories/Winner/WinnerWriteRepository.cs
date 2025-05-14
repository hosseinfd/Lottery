using Domain.RepoInterfaces.Winner;

namespace Infrastructure.Repositories.Winner;

public class WinnerWriteRepository : WriteRepository<Domain.Winner.Winner>, IWinnerWriteRepository
{
    private readonly AppDbContext _context;

    public WinnerWriteRepository(AppDbContext context) : base(context) => _context = context;
}