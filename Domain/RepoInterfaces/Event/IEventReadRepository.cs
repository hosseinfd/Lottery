using Domain.Entities.Event.Dto;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IEventReadRepository : IReadRepository<Entities.Event.Event>
{
    public Task<Entities.Event.Scenario?> GetScenarioByIdAsync(Guid scenarioId);

    public Task<Entities.Event.Event?> GetEventByIdAsync(Guid eventId);

    Task<IEnumerable<EventDto>> GetActiveEventsAsync(DateTime currentDate, CancellationToken ct = default);
    Task<bool> IsActiveAsync(Guid eventId, CancellationToken ct = default);
}