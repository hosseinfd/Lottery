using Domain.Event;

namespace Domain.Winner;

public class Winner
{
    public Guid WinnerId { get; set; }
    public Guid ScenarioId { get; set; }
    public Guid UserId { get; set; }
    public Guid CurrencyId { get; set; }
    public decimal RewardValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public Scenario Scenario { get; set; }
    public User.User User { get; set; }
    public Currency.Currency Currency { get; set; }
}
