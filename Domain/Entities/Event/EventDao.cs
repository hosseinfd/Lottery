using Domain.Common.EntityAttributeInterfaces;
using Domain.Entities.UserTransaction;

namespace Domain.Entities.Event;

public class EventDao : ISoftDeleted
{
    public Guid EventId { get; private set; }
    public string Type { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; set; }
    public DateTime? DeactivatedAt { get; set; }
    public string EventRules { get; private set; }
    public ICollection<UserTransactionDao> UserTransactions { get; private set; }
}