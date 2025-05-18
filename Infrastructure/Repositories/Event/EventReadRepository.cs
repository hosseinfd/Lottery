using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Event.Dto;
using Domain.RepoInterfaces.Event;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Event;

public class EventReadRepository :ReadRepository<Domain.Entities.Event.Event>, IEventReadRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EventReadRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Domain.Entities.Event.Scenario?> GetScenarioByIdAsync(Guid scenarioId) =>
        await _context.Scenarios.FindAsync(scenarioId);

    public async Task<Domain.Entities.Event.Event?> GetEventByIdAsync(Guid eventId) =>
        await _context.Events.FindAsync(eventId);
    
    public async Task<IEnumerable<EventDto>> GetActiveEventsAsync(DateTime currentDate, CancellationToken ct = default)
    {
        
        return await _context.Events
            .Where(e => e.StartDate <= currentDate && e.EndDate >= currentDate && e.IsActive)
            .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
            .ToListAsync(ct);
    }

    public async Task<bool> IsActiveAsync(Guid eventId, CancellationToken ct = default)
    {
        return await _context.Events
            .AnyAsync(e => e.EventId == eventId && e.IsActive, ct);
    }
}