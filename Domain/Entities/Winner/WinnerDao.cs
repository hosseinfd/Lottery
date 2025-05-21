using Domain.Common.EntityAttributeInterfaces;
using Domain.Entities.Currency;
using Domain.Entities.Event;
using Domain.Entities.User;

namespace Domain.Entities.Winner;

public class WinnerDao : ISoftDeleted
{
    public Guid WinnerId { get; private set; }
    public Guid ScenarioId { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CurrencyId { get; private set; }
    public decimal RewardValue { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ScenarioDao ScenarioDao { get; private set; }
    public UserDao UserDao { get; private set; }
    public CurrencyDao CurrencyDao { get; private set; }
    public bool IsActive { get; set; }
    public DateTime? DeactivatedAt { get; set; }
}