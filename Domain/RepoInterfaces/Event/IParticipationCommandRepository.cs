using Domain.Entities.Event;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IParticipationCommandRepository : IWriteRepository<EventParticipation>
{
    Task<EventParticipation?> GetAsync(Guid userId, Guid eventId, CancellationToken ct = default);
    Task CompleteParticipationAsync(Guid participationId, CancellationToken ct = default);
    Task<bool> IsParticipatingAsync(Guid userId, Guid eventId, CancellationToken ct = default);
    Task<IEnumerable<EventParticipation>> GetUserParticipationsAsync(Guid userId, CancellationToken ct = default);
}