using Domain.User;

namespace Application.Utility;

public static class UserMapper
{
    public static UserDto MapToDto(this Domain.User.User user) => new UserDto
    {
        UserId = user.UserId,
        TelegramId = user.TelegramId,
        Username = user.Username,
        Name = user.Name,
        CreatedAt = user.CreatedAt
    };
}