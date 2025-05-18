using AutoMapper;
using Domain.RepoInterfaces.UserBalance;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.UserBalance;

public class UserBalanceWriteRepository: WriteRepository<Domain.Entities.UserBalance.UserBalanceDao>,IUserBalanceWriteRepository
{
    private readonly AppDbContext _context;
    public UserBalanceWriteRepository(AppDbContext context, IMapper mapper) :base(context)
    {
        _context = context;
    }

    public Task UpdateAsync(Domain.Entities.UserBalance.UserBalanceDao balanceDao)
    {
        _context.UserBalances.Update(balanceDao);
        return Task.CompletedTask;
    }
    
}