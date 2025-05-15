using Domain.Entities.Event;
using Domain.RepoInterfaces.Event;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Event;

public class EventWriteRepository : WriteRepository<EventDao>, IEventWriteRepository
{
    private readonly AppDbContext _context;

    public EventWriteRepository(AppDbContext context) : base(context) => _context = context;

    public async Task<EventDao?> GetByIdAsync(Guid id)
    {
        return await _context.Events.Where(q => q.Id == id).Select(q => q).FirstOrDefaultAsync();
    }

    public async Task AddParticipationAsync(EventParticipationDao participationDao, CancellationToken ct = default) =>
        await _context.EventParticipations.AddAsync(participationDao, ct);

    public async Task<bool> EventNameExistsAsync(string name, CancellationToken ct = default)
    {
        return await _context.Events.AnyAsync(q => q.Title == name, ct);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Events.AnyAsync(q => q.Id == id, ct);
    }

    public async Task AddScenarioAsync(ScenarioDao scenarioDao, CancellationToken ct = default) =>
        await _context.Scenarios.AddAsync(scenarioDao, ct);
}