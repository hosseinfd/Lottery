using AutoMapper;
using Domain.Interfaces;
using Domain.RepoInterfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private bool _disposed;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly IMapper _mapper;

    public UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // var modifiedCollections = _context.ChangeTracker.Entries().Where(q => q.State == EntityState.Modified);
        // var modifiedMember = modifiedCollections.Select(q => q.Members.Select(w => w.IsModified)).ToString();
        // _logger.LogInformation(modifiedMember);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public IWriteRepository<T> WriteRepository<T>() where T : class
    {
        return new WriteRepository<T>(_context);
    }

    public IReadRepository<T> ReadRepository<T>() where T : class
    {
        return new ReadRepository<T>(_context, _mapper);
    }

    // Dispose the context to release resources
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}