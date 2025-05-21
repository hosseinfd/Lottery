using Domain.Entities.Event;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IParticipationCommandRepository : IWriteRepository<EventParticipationDao>
{
    Task<EventParticipationDao?> GetAsync(Guid userId, Guid eventId, CancellationToken ct = default);
    Task CompleteParticipationAsync(Guid participationId, CancellationToken ct = default);
    Task<bool> IsParticipatingAsync(Guid userId, Guid eventId, CancellationToken ct = default);
    Task<IEnumerable<EventParticipationDao>> GetUserParticipationsAsync(Guid userId, CancellationToken ct = default);
}