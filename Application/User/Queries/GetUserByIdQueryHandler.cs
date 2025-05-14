using Application.BuildingBlocks.CQRS.Queries;
using Application.Utility;
using Domain.RepoInterfaces.User;
using Domain.User;

namespace Application.User.Queries;

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
        return user is null ? null : UserMapper.MapToDto(user);
    }
}