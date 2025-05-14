using Domain.Event.Dto;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IEventReadRepository : IReadRepository<Domain.Event.Event>
{
    public Task<Domain.Event.Scenario?> GetScenarioByIdAsync(Guid scenarioId);

    public Task<Domain.Event.Event?> GetEventByIdAsync(Guid eventId);

    Task<IEnumerable<EventDto>> GetActiveEventsAsync(DateTime currentDate, CancellationToken ct = default);
    Task<bool> IsActiveAsync(Guid eventId, CancellationToken ct = default);
}