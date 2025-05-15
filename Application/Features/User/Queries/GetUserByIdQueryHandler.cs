using Application.BuildingBlocks.CQRS.Queries;
using Application.Mappings;
using Domain.Entities.User;
using Domain.RepoInterfaces.User;

namespace Application.Features.User.Queries;

public class GetUserByIdQueryHandler: IQueryHandler<UserQueries.GetUserByIdQuery, UserDto?>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetUserByIdQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<UserDto?> Handle(UserQueries.GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetByIdAsync(request.UserId);
        return user is null ? null : UserProfile.MapToDto(user);
    }
}