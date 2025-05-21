using AutoMapper;
using Domain.RepoInterfaces.UserTransaction;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserTransaction;

public class UserTransactionReadRepository: ReadRepository<Domain.Entities.UserTransaction.UserTransactionDao>,IUserTransactionReadRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserTransactionReadRepository(AppDbContext context, IMapper mapper) :base(context,mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Domain.Entities.UserTransaction.UserTransactionDao>> GetByUserIdAsync(Guid userId) =>
        await _context.UserTransactions.Where(t => t.UserId == userId).ToListAsync();
}