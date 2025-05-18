using Domain.Entities.Event;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IEventWriteRepository : IWriteRepository<Entities.Event.Event>
{
    public Task AddParticipationAsync(EventParticipation participation, CancellationToken ct = default);

    public Task AddScenarioAsync(Entities.Event.Scenario scenario,CancellationToken ct = default);
    
    Task<bool> EventNameExistsAsync(string name, CancellationToken ct = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);

}