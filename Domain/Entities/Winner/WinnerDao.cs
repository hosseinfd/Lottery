using Domain.Entities.Event;
using Domain.Services;

namespace Domain.Entities.Winner;

public class WinnerDao : Entity
{
    public Guid ScenarioId { get; set; }
    public Guid UserId { get; set; }
    public Guid CurrencyId { get; set; }
    public decimal RewardValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public ScenarioDao ScenarioDao { get; set; }
    public User.UserDao UserDao { get; set; }
    public Currency.CurrencyDao CurrencyDao { get; set; }
}
