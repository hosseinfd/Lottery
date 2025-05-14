using Domain.Event;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IEventWriteRepository : IWriteRepository<Domain.Event.Event>
{
    public Task AddParticipationAsync(EventParticipation participation, CancellationToken ct = default);

    public Task AddScenarioAsync(Domain.Event.Scenario scenario,CancellationToken ct = default);
    
    Task<bool> EventNameExistsAsync(string name, CancellationToken ct = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);

}