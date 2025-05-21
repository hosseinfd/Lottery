using Domain.Common.EntityAttributeInterfaces;

namespace Domain.Entities.Event;

public class ScenarioDao : ISoftDeleted
{
    public Guid ScenarioId { get; private set; }
    public Guid EventId { get; private set; }
    public string Condition { get; private set; }
    public string RewardType { get; private set; }
    public decimal RewardValue { get; private set; }
    public string AdditionalData { get; private set; }
    public EventDao EventDao { get; private set; }
    public bool IsActive { get; set; }
    public DateTime? DeactivatedAt { get; set; }
}