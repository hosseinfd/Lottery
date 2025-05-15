using System.Collections.Concurrent;
using Domain.Interfaces;
using Domain.RepoInterfaces;
using Domain.ServiceInterfaces;
using Domain.Services;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private IDbContextTransaction? _currentTransaction;
    private IExecutionStrategy? _executionStrategy;
    private readonly ConcurrentDictionary<Type, object> _repositories = new();
    private bool _disposed;


    public IWriteRepository<T> WriteRepository<T>() where T : Entity, IEntity
    {
        if (_repositories.TryGetValue(typeof(T), out var repository))
        {
            return (WriteRepository<T>)repository;
        }

        var newRepo = new WriteRepository<T>(dbContext);
        _repositories.TryAdd(typeof(T), newRepo);
        return newRepo;
    }

    public IReadRepository<T> ReadRepository<T>() where T : Entity, IEntity
    {
        if (_repositories.TryGetValue(typeof(T), out var repository))
        {
            return (ReadRepository<T>)repository;
        }

        var newRepo = new ReadRepository<T>(dbContext);
        _repositories.TryAdd(typeof(T), newRepo);
        return newRepo;
    }
    
    public async Task<Guid> BeginTransaction(
        CancellationToken cancellationToken = new CancellationToken())
    {
        _currentTransaction ??= await dbContext.Database.BeginTransactionAsync(cancellationToken);
        return _currentTransaction.TransactionId;
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        if (_currentTransaction != null)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);
                await _currentTransaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        if (_currentTransaction != null)
        {
            try
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public IExecutionStrategy CreateExecutionStrategy()
    {
        return _executionStrategy ??= dbContext.Database.CreateExecutionStrategy();
    }


    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;

        if (_currentTransaction != null)
        {
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
            _executionStrategy = null;
        }

        await dbContext.DisposeAsync();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}