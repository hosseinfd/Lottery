namespace Domain.User;

public class UserDto
{
    public Guid UserId { get; set; }
    public string TelegramId { get; set; } = default!;
    public string? Username { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
}