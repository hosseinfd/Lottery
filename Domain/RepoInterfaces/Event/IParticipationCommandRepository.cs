using Domain.Entities.Event;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Event;

public interface IParticipationCommandRepository : IWriteRepository<EventParticipantsDao>
{
    Task<EventParticipantsDao?> GetAsync(Guid userId, Guid eventId, CancellationToken ct = default);
    Task CompleteParticipationAsync(Guid participationId, CancellationToken ct = default);
    Task<bool> IsParticipatingAsync(Guid userId, Guid eventId, CancellationToken ct = default);
    Task<IEnumerable<EventParticipantsDao>> GetUserParticipationsAsync(Guid userId, CancellationToken ct = default);
}