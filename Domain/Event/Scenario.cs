namespace Domain.Event;

public class Scenario
{
    public Guid ScenarioId { get; set; }
    public Guid EventId { get; set; }
    public string Condition { get; set; }
    public string RewardType { get; set; }
    public decimal RewardValue { get; set; }
    public string AdditionalData { get; set; }
    public Domain.Event.Event Event { get; set; }
}