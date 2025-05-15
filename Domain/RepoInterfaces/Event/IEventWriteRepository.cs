using Domain.Entities.Event;

namespace Domain.RepoInterfaces.Event;

public interface IEventWriteRepository : IWriteRepository<EventDao>
{
    public Task AddParticipationAsync(EventParticipationDao participationDao, CancellationToken ct = default);

    public Task AddScenarioAsync(ScenarioDao scenarioDao,CancellationToken ct = default);
    
    Task<bool> EventNameExistsAsync(string name, CancellationToken ct = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);

}