using Domain.Entities.UserTransaction;
using Domain.Services;

namespace Domain.Entities.Event;

public class EventDao : Entity
{
    public string Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public string EventRules { get; set; }
    public ICollection<TransactionDao> UserTransactions { get; set; }
}