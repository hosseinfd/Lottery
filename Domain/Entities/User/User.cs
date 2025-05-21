namespace Domain.Entities.User;

public class User
{
    public Guid UserId { get; set; }
    public string TelegramId { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}
