using AutoMapper;
using Domain.Entities.UserTransaction;
using Domain.RepoInterfaces.UserTransaction;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserTransaction;

public class UserTransactionReadRepository(AppDbContext context) : ReadRepository<TransactionDao>(context), IUserTransactionReadRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<TransactionDao>> GetByUserIdAsync(Guid userId) =>
        await _context.UserTransactions.Where(t => t.UserId == userId).ToListAsync();
}