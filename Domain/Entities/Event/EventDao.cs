using Domain.Entities.UserTransaction;

namespace Domain.Entities.Event;

public class EventDao
{
    public Guid EventId { get; }
    public string Type { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public bool IsActive { get; }
    public string EventRules { get; }
    public ICollection<UserTransactionDao> UserTransactions { get; }
}