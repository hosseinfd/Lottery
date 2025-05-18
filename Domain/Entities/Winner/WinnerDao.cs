using Domain.Entities.Currency;
using Domain.Entities.Event;
using Domain.Entities.User;

namespace Domain.Entities.Winner;

public class WinnerDao
{
    public Guid WinnerId { get; }
    public Guid ScenarioId { get; }
    public Guid UserId { get; }
    public Guid CurrencyId { get; }
    public decimal RewardValue { get; }
    public DateTime CreatedAt { get; }
    public ScenarioDao ScenarioDao { get; }
    public UserDao UserDao { get; }
    public CurrencyDao CurrencyDao { get; }
}