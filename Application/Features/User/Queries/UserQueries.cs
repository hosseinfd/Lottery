using Application.BuildingBlocks.CQRS.Queries;
using Domain.Entities.User;

namespace Application.Features.User.Queries;

public class UserQueries
{
    public record GetUserByTelegramIdQuery(string TelegramId) : IQuery<UserDto?>;
    public record GetUserByIdQuery(Guid UserId) : IQuery<UserDto?>;
    public record GetAllUsersQuery() : IQuery<List<UserDto>>;
    
}