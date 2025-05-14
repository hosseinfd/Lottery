namespace Domain.Event.Dto;

public class ScenarioDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Condition { get; set; }
    public string RewardType { get; set; }
    public decimal RewardValue { get; set; }
    public string RewardCurrencySymbol { get; set; }
    public Dictionary<string, object> AdditionalData { get; set; } = new();
}