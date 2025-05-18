namespace Domain.Entities.Event;

public class ScenarioDao
{
    public Guid ScenarioId { get; }
    public Guid EventId { get; }
    public string Condition { get; }
    public string RewardType { get; }
    public decimal RewardValue { get; }
    public string AdditionalData { get; }
    public EventDao EventDao { get; }
}