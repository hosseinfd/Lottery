
namespace Domain.Entities.Event;

public class EventParticipation
{
    public Guid Id { get; set; }
    public Guid ParticipationId { get; set; }
    public Guid UserId { get; set; }
    public Guid ScenarioId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public User.User User { get; set; }
    public Scenario Scenario { get; set; }
    public Guid EventId { get; set; }
    public Entities.Event.Event Event { get; set; }

    // Domain methods
    public void Complete()
    {
        Status = "completed";
        CompletedAt = DateTime.UtcNow;
    }

    public void Fail()
    {
        Status = "failed";
        CompletedAt = DateTime.UtcNow;
    }

    // Constructor
    public EventParticipation(Guid userId, Guid eventId, DateTime createdAt)
    {
        UserId = userId;
        EventId = eventId;
        Status = "pending";
        CreatedAt = createdAt;
    }
}
