using Domain.Entities.Event;

namespace Domain.Entities.UserTransaction;

public class UserTransaction
{
    public Guid TransactionId { get; set; }
    public Guid UserId { get; set; }
    public Guid CurrencyId { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }
    public Guid EventId { get; set; }
    public Guid ReferenceId { get; set; }
    public string Details { get; set; }
    public DateTime CreatedAt { get; set; }
    public Entities.User.User User { get; set; }
    public Entities.Currency.Currency Currency { get; set; }
    public Entities.Event.Event Event { get; set; }
    public Guid? ScenarioId { get; private set; }
    public Scenario? Scenario { get; private set; }}