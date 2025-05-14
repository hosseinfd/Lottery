using Application.BuildingBlocks.CQRS.Queries;
using Domain;
using Domain.RepoInterfaces.Currency;
using Domain.RepoInterfaces.UserTransaction;
using Domain.UserTransaction;

namespace Application.UserTransaction.Queries;

public class GetUserTransactionsQueryHandler: IQueryHandler<UserTransactionQueries.GetUserTransactionsQuery, PagedList<TransactionDto>>
{
    private readonly IUserTransactionReadRepository _transactionRepo;
    private readonly ICurrencyReadRepository _currencyRepo;

    public GetUserTransactionsQueryHandler(
        IUserTransactionReadRepository transactionRepo,
        ICurrencyReadRepository currencyRepo)
    {
        _transactionRepo = transactionRepo;
        _currencyRepo = currencyRepo;
    }

    public async Task<PagedList<TransactionDto>> Handle(
        UserTransactionQueries.GetUserTransactionsQuery request,
        CancellationToken ct)
    {
        var query = _transactionRepo.GetUserTransactionsQuery(request.UserId);
        var totalCount = await query.CountAsync(ct);
        
        var transactions = await query
            .OrderByDescending(t => t.CreatedAt)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(ct);

        var currencies = await _currencyRepo.GetAllAsync(ct);

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