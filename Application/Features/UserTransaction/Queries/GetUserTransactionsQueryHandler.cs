using Application.BuildingBlocks.CQRS.Queries;
using Domain;
using Domain.Entities.UserTransaction;
using Domain.RepoInterfaces.Currency;
using Domain.RepoInterfaces.UserTransaction;

namespace Application.Features.UserTransaction.Queries;

public class GetUserTransactionsQueryHandler(
    IUserTransactionReadRepository transactionRepo,
    ICurrencyReadRepository currencyRepo
) : IQueryHandler<UserTransactionQueries.GetUserTransactionsQuery, PagedList<TransactionDto>>
{
    public async Task<PagedList<TransactionDto>> Handle(
        UserTransactionQueries.GetUserTransactionsQuery request,
        CancellationToken ct)
    {
        var query = transactionRepo.GetByUserIdAsync(request.UserId);
        var totalCount =  query.Result.Count();

        var transactions = await query
            .OrderByDescending(t => t.CreatedAt)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(ct);

        var currencies = await currencyRepo.GetAllAsync(ct);

        var dtos = transactions.Select(t => new TransactionDto
        {
            Amount = t.Amount,
            CurrencySymbol = currencies.First(c => c.CurrencyId == t.CurrencyId).Symbol,
            Type = t.TransactionType.ToString(),
            Description = t.Description,
            CreatedAt = t.CreatedAt
        }).ToList();

        return new PagedList<TransactionDto>(
            dtos,
            totalCount,
            request.Page,
            request.PageSize);
    }
}