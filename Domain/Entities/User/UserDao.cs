using Domain.Common.EntityAttributeInterfaces;

namespace Domain.Entities.User;

public class UserDao : ISoftDeleted
{
    public Guid UserId { get; private set; }
    public string TelegramId { get; private set; }
    public string Username { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; set; }
    public DateTime? DeactivatedAt { get; set; }
}