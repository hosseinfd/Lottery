namespace Domain.AuditLog;

public class AuditLog
{
    public Guid LogId { get; set; }  // UUID as primary key
    public string ActionType { get; set; }
    public Guid? UserId { get; set; }  // Nullable foreign key to User
    public Guid? EventId { get; set; }  // Nullable foreign key to Event
    public string Details { get; set; }
    public DateTime Timestamp { get; set; }
}