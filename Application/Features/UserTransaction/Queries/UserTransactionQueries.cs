﻿using Application.BuildingBlocks.CQRS.Queries;
using Domain.Common.Pagination;
using Domain.Entities.UserTransaction;

namespace Application.Features.UserTransaction.Queries;

public class UserTransactionQueries
{
    public record GetUserTransactionsQuery(Guid UserId, int Page = 1, int PageSize = 10) 
        : IQuery<PagedList<TransactionDto>>;
}