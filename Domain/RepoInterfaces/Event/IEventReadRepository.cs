using Domain.Entities.Event;
using Domain.Entities.Event.Dto;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IEventReadRepository : IReadRepository<EventDao>
{
    public Task<ScenarioDao?> GetScenarioByIdAsync(Guid scenarioId);

    public Task<EventDao?> GetEventByIdAsync(Guid eventId);

    Task<IEnumerable<EventDto>> GetActiveEventsAsync(DateTime currentDate, CancellationToken ct = default);
    Task<bool> IsActiveAsync(Guid eventId, CancellationToken ct = default);
}