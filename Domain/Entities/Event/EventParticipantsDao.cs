using Domain.Common.EntityAttributeInterfaces;
using Domain.Entities.User;

namespace Domain.Entities.Event;

public class EventParticipantsDao : IEntity, ISoftDeleted, ICreated
{
    public Guid Id { get; set; }
    public Guid ParticipantId { get; private set; }
    public Guid UserId { get; private set; }
    public Guid ScenarioId { get; private set; }
    public Guid EventId { get; private set; }
    public string Status { get; private set; }

    public DateTime? CompletedAt { get; private set; }

    public bool IsActive { get; set; }
    public DateTime? DeactivatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    // navigation properties
    public UserDao UserDao { get; private set; }
    public ScenarioDao ScenarioDao { get; private set; }

    public EventDao EventDao { get; private set; }

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
    public EventParticipantsDao(Guid userId, Guid eventId, DateTime createdAt)
    {
        UserId = userId;
        EventId = eventId;
        Status = "pending";
        CreatedAt = createdAt;
    }
}