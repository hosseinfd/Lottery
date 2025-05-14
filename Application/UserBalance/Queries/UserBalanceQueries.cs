using Application.BuildingBlocks.CQRS.Queries;
using Domain.UserBalance;

namespace Application.UserBalance.Queries;

public class UserBalanceQueries
{
    public record GetUserBalanceQuery(Guid UserId) : IQuery<List<UserBalanceDto>>;

}