using Domain.Entities.Event;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IEventWriteRepository : IWriteRepository<Entities.Event.EventDao>
{
    public Task AddParticipationAsync(EventParticipantsDao participantsDao, CancellationToken ct = default);

    public Task AddScenarioAsync(Entities.Event.ScenarioDao scenarioDao,CancellationToken ct = default);
    
    Task<bool> EventNameExistsAsync(string name, CancellationToken ct = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);

}