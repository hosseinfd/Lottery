using Domain.Common.EntityAttributeInterfaces;
using Domain.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence.Interceptors;

public class EntityCommonAttributesInterceptor(IDateTimeProvider timeProvider) : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context == null) return result;

        var context = eventData.Context;
        foreach (var entry in context.ChangeTracker.Entries())
        {
            switch (entry)
            {
                case { State: EntityState.Added }:
                    if (entry.Entity is IEntity entityAdded)
                    {
                        entityAdded.Id = Guid.CreateVersion7();
                    }

                    if (entry.Entity is ICreated entityCreated)
                    {
                        entityCreated.CreatedAt = timeProvider.Now;
                    }

                    break;
                case { State: EntityState.Deleted, Entity: ISoftDeleted entityDeleted }:
                    entityDeleted.IsActive = false;
                    entityDeleted.DeactivatedAt = timeProvider.Now;
                    entry.State = EntityState.Modified;
                    break;
                case { State: EntityState.Modified, Entity: IUpdated entityUpdated }:
                    entityUpdated.UpdatedAt = timeProvider.Now;
                    break;
            }
        }

        return result;
    }
}