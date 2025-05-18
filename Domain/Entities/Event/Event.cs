namespace Domain.Entities.Event;

public class Event
{
    public Guid EventId { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public string EventRules { get; set; }
    public ICollection<UserTransaction.UserTransaction> UserTransactions { get; set; }
}