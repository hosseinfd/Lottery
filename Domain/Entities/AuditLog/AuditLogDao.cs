using Domain.Common.EntityAttributeInterfaces;

namespace Domain.Entities.AuditLog;

public class AuditLogDao : ISoftDeleted
{
    public Guid LogId { get; private set; } // UUID as primary key
    public string ActionType { get; private set; }
    public Guid? UserId { get; private set; } // Nullable foreign key to User
    public Guid? EventId { get; private set; } // Nullable foreign key to Event
    public string Details { get; private set; }
    public DateTime Timestamp { get; private set; }
    public bool IsActive { get; set; }
    public DateTime? DeactivatedAt { get; set; }
}