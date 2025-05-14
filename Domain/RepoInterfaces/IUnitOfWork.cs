namespace Domain.RepoInterfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    
    // IWriteRepository<T> WriteRepository<T>() where T : class;
    // IReadRepository<T> ReadRepository<T>() where T : class;
    
}