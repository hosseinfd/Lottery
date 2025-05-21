namespace Domain.Entities.User;

public class UserDao
{
    public Guid UserId { get; }
    public string TelegramId { get; }
    public string Username { get; }
    public string Name { get; }
    public DateTime CreatedAt { get; }
}
