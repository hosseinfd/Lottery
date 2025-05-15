using AutoMapper;
using Domain.Entities.UserBalance;
using Domain.RepoInterfaces.UserBalance;

namespace Infrastructure.Repositories.UserBalance;

public class UserBalanceWriteRepository: WriteRepository<UserBalanceDao>,IUserBalanceWriteRepository
{
    private readonly AppDbContext _context;
    public UserBalanceWriteRepository(AppDbContext context, IMapper mapper) :base(context)
    {
        _context = context;
    }

    public Task UpdateAsync(UserBalanceDao balanceDao)
    {
        _context.UserBalances.Update(balanceDao);
        return Task.CompletedTask;
    }
    
}