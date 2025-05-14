using Application.BuildingBlocks.CQRS.Queries;
using Domain;
using Domain.UserTransaction;

namespace Application.UserTransaction.Queries;

public class UserTransactionQueries
{
    public record GetUserTransactionsQuery(Guid UserId, int Page = 1, int PageSize = 10) 
        : IQuery<PagedList<TransactionDto>>;
}