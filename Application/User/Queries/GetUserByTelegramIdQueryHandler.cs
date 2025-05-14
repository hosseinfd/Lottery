using Application.BuildingBlocks.CQRS.Queries;
using Domain.RepoInterfaces.User;
using Domain.User;

namespace Application.User.Queries;

public class GetUserByTelegramIdQueryHandler : IQueryHandler<UserQueries.GetUserByTelegramIdQuery, UserDto?>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetUserByTelegramIdQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<UserDto?> Handle(UserQueries.GetUserByTelegramIdQuery request, CancellationToken cancellationToken)
    {
        var user =  await _userReadRepository.GetByTelegramIdAsync(request.TelegramId);
        return user is null ? null : new UserDto
        {
            UserId = user.UserId,
            TelegramId = user.TelegramId,
            Username = user.Username,
            Name = user.Name,
            CreatedAt = user.CreatedAt
        };
    }
}