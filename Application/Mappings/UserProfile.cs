using AutoMapper;
using Domain.Entities.User;

namespace Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Domain.Entities.User.User, UserDto>()
            .ConvertUsing(user =>
                new UserDto
                {
                    UserId = user.UserId,
                    TelegramId = user.TelegramId,
                    Username = user.Username,
                    Name = user.Name,
                    CreatedAt = user.CreatedAt
                }
            );
    }
}