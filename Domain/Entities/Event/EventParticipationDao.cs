using Domain.Entities.User;
using Domain.Services;

namespace Domain.Entities.Event;

public sealed class EventParticipationDao : Entity
{
    public Guid ParticipationId { get; set; }
    public Guid UserId { get; set; }
    public Guid ScenarioId { get; set; }
    public string Status { get; set; }
    public DateTime? CompletedAt { get; set; }
    public UserDao UserDao { get; set; }
    public ScenarioDao ScenarioDao { get; set; }
    public Guid EventId { get; set; }
    public EventDao EventDao { get; set; }

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
    public EventParticipationDao(Guid userId, Guid eventId, DateTime createdAt)
    {
        UserId = userId;
        EventId = eventId;
        Status = "pending";
        CreatedAt = createdAt;
    }
}
