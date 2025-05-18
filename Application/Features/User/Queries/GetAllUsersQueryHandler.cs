using Application.BuildingBlocks.CQRS.Queries;
using Domain.Entities.User;
using Domain.RepoInterfaces.User;

namespace Application.Features.User.Queries;

public class GetAllUsersQueryHandler: IQueryHandler<UserQueries.GetAllUsersQuery, List<UserDto>>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetAllUsersQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<List<UserDto>> Handle(UserQueries.GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userReadRepository.GetAllAsync();
        return users.Select(u => u.MapToDto()).ToList();
    }
}