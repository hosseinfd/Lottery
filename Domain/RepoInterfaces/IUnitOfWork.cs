using Domain.Interfaces;
using Domain.ServiceInterfaces;
using Domain.Services;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.RepoInterfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    IWriteRepository<T> WriteRepository<T>() where T : Entity, IEntity;
    IReadRepository<T> ReadRepository<T>() where T : Entity, IEntity;
    Task<Guid> BeginTransaction(CancellationToken cancellationToken = new CancellationToken());
    Task CommitTransactionAsync(CancellationToken cancellationToken = new CancellationToken());
    Task RollbackTransactionAsync(CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    IExecutionStrategy CreateExecutionStrategy();

    // IWriteRepository<T> WriteRepository<T>() where T : class;
    // IReadRepository<T> ReadRepository<T>() where T : class;
}