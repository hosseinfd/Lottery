using Application.BuildingBlocks.CQRS.Queries;
using Domain.User;

namespace Application.User.Queries;

public class UserQueries
{
    public record GetUserByTelegramIdQuery(string TelegramId) : IQuery<UserDto?>;
    public record GetUserByIdQuery(Guid UserId) : IQuery<UserDto?>;
    public record GetAllUsersQuery() : IQuery<List<UserDto>>;
    
}