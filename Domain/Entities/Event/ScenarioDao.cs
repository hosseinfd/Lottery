using Domain.Services;

namespace Domain.Entities.Event;

public sealed class ScenarioDao : Entity
{
    public Guid EventId { get; set; }
    public string Condition { get; set; }
    public string RewardType { get; set; }
    public decimal RewardValue { get; set; }
    public string AdditionalData { get; set; }
    public EventDao EventDao { get; set; }
}