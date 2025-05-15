using Domain.Services;

namespace Domain.Entities.AuditLog;

public class AuditLogDao : Entity
{
    public string ActionType { get; set; }
    public Guid? UserId { get; set; }  // Nullable foreign key to User
    public Guid? EventId { get; set; }  // Nullable foreign key to Event
    public string Details { get; set; }
    public DateTime Timestamp { get; set; }
}