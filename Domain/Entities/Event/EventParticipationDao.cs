using Domain.Entities.User;

namespace Domain.Entities.Event;

public class EventParticipationDao
{
    public Guid Id { get; }
    public Guid ParticipationId { get; }
    public Guid UserId { get; }
    public Guid ScenarioId { get; }
    public string Status { get; }
    public DateTime CreatedAt { get; }
    public DateTime? CompletedAt { get; }
    public UserDao UserDao { get; }
    public ScenarioDao ScenarioDao { get; }
    public Guid EventId { get; }
    public EventDao EventDao { get; }

    // Domain methods
    public void Complete()
    {
        // Status = "completed";
        // CompletedAt = DateTime.UtcNow;
    }

    public void Fail()
    {
        // Status = "failed";
        // CompletedAt = DateTime.UtcNow;
    }

    // Constructor
    public EventParticipationDao(Guid userId, Guid eventId, DateTime createdAt)
    {
        UserId = userId;
        EventId = eventId;
        Status = "pending";
        CreatedAt = createdAt;
    }
}