using Domain.Entities.Currency;
using Domain.Entities.Event;
using Domain.Entities.User;

namespace Domain.Entities.UserTransaction;

public class UserTransactionDao
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
    public UserDao UserDao { get; set; }
    public CurrencyDao CurrencyDao { get; set; }
    public EventDao EventDao { get; set; }
    public Guid? ScenarioId { get; private set; }
    public ScenarioDao? Scenario { get; private set; }
}