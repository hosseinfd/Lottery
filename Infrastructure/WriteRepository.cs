using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class WriteRepository<T> : IWriteRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken ct = default)
    {
        await _context.Set<T>().AddAsync(entity,ct);
    }


    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<T?> GetByIdAsync(Guid id,CancellationToken ct = default)
    {
        return await _context.Set<T>().FindAsync(id,ct);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct= default)
    {
        return await _context.Set<T>().ToListAsync(ct);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }

}