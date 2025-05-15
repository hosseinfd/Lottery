using AutoMapper;
using Domain.Entities.User;

namespace Application.Mappings;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDao, UserDto>().ConstructUsing(user => new UserDto
        {
            UserId = user.Id,
            TelegramId = user.TelegramId,
            Username = user.Username,
            Name = user.Name,
            CreatedAt = user.CreatedAt
        });
    }
}