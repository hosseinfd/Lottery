using Application.BuildingBlocks.CQRS.Queries;
using Domain.Entities.UserBalance;

namespace Application.Features.UserBalance.Queries;

public class UserBalanceQueries
{
    public record GetUserBalanceQuery(Guid UserId) : IQuery<List<UserBalanceDto>>;

}