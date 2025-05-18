namespace Domain.Entities.AuditLog;

public class AuditLogDao
{
    public Guid LogId { get; } // UUID as primary key
    public string ActionType { get; }
    public Guid? UserId { get; } // Nullable foreign key to User
    public Guid? EventId { get; } // Nullable foreign key to Event
    public string Details { get; }
    public DateTime Timestamp { get; }
}