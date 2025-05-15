using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Event;
using Domain.Entities.Event.Dto;
using Domain.RepoInterfaces.Event;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Event;

public class EventReadRepository(AppDbContext context, IMapper mapper) : ReadRepository<EventDao>(context), IEventReadRepository
{
    public async Task<ScenarioDao?> GetScenarioByIdAsync(Guid scenarioId) =>
        await context.Scenarios.FindAsync(scenarioId);

    public async Task<EventDao?> GetEventByIdAsync(Guid eventId) =>
        await context.Events.FindAsync(eventId);

    public async Task<IEnumerable<EventDto>> GetActiveEventsAsync(DateTime currentDate, CancellationToken ct = default)
    {
        var s = await context.Events
            .Where(e => e.StartDate <= currentDate && e.EndDate >= currentDate && e.IsActive)
            .ToListAsync(ct);
        return s.Select(mapper.Map<EventDto>);
    }

    public async Task<bool> IsActiveAsync(Guid eventId, CancellationToken ct = default)
    {
        return await context.Events
            .AnyAsync(e => e.Id == eventId && e.IsActive, ct);
    }
}