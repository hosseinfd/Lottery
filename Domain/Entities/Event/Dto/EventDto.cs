namespace Domain.Entities.Event.Dto;

public class EventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsParticipating { get; set; }
    public int TotalParticipants { get; set; }
    public List<ScenarioDto> Scenarios { get; set; } = new();
    public Dictionary<string, object> EventRules { get; set; } = new();
}