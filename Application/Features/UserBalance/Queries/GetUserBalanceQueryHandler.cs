using Application.BuildingBlocks.CQRS.Queries;
using Domain;
using Domain.Entities.UserBalance;

namespace Application.Features.UserBalance.Queries;

public class GetUserBalanceQueryHandler: IQueryHandler<UserBalanceQueries.GetUserBalanceQuery, List<UserBalanceDto>>
{
    private readonly IUserBalanceRepository _balanceRepo;
    private readonly ICurrencyRepository _currencyRepo;

    public GetUserBalanceQueryHandler(
        IUserBalanceRepository balanceRepo,
        ICurrencyRepository currencyRepo)
    {
        _balanceRepo = balanceRepo;
        _currencyRepo = currencyRepo;
    }

    public async Task<List<UserBalanceDto>> Handle(
        UserBalanceQueries.GetUserBalanceQuery request,
        CancellationToken ct)
    {
        var balances = await _balanceRepo.GetUserBalancesAsync(request.UserId, ct);
        var currencies = await _currencyRepo.GetAllAsync(ct);

        var result = balances.Join(
            currencies,
            b => b.CurrencyId,
            c => c.Id,
            (b, c) => new UserBalanceDto
            {
                Amount = b.Amount,
                CurrencySymbol = c.Symbol,
                CurrencyName = c.Name
            }).ToList();

        return Result.Success(result);
    }
}