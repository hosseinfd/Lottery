using Domain.ServiceInterfaces;
using Domain.Services;

namespace Domain.Entities.User;

public class UserDao : Entity
{
    public string TelegramId { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}