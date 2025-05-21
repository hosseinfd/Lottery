using Domain.Common.EntityAttributeInterfaces;
using Domain.Entities.Currency;
using Domain.Entities.Event;
using Domain.Entities.User;

namespace Domain.Entities.UserTransaction;

public class UserTransactionDao : ISoftDeleted
{
    public Guid TransactionId { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CurrencyId { get; private set; }
    public decimal Amount { get; private set; }
    public string TransactionType { get; private set; }
    public Guid EventId { get; private set; }
    public Guid ReferenceId { get; private set; }
    public string Details { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public UserDao UserDao { get; private set; }
    public CurrencyDao CurrencyDao { get; private set; }
    public EventDao EventDao { get; private set; }
    public Guid? ScenarioId { get; private set; }
    public ScenarioDao? Scenario { get; private set; }
    public bool IsActive { get; set; }
    public DateTime? DeactivatedAt { get; set; }
}