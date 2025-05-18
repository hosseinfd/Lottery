using Domain.Entities.Event.Dto;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IEventReadRepository : IReadRepository<Entities.Event.EventDao>
{
    public Task<Entities.Event.ScenarioDao?> GetScenarioByIdAsync(Guid scenarioId);

    public Task<Entities.Event.EventDao?> GetEventByIdAsync(Guid eventId);

    Task<IEnumerable<EventDto>> GetActiveEventsAsync(DateTime currentDate, CancellationToken ct = default);
    Task<bool> IsActiveAsync(Guid eventId, CancellationToken ct = default);
}