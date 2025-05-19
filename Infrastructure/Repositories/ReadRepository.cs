using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReadRepository<T>(AppDbContext context, IMapper mapper) : IReadRepository<T>
    where T : class
{
    protected readonly IMapper Mapper = mapper;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object?[] { id, cancellationToken }, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbSet.ToListAsync(default);
    }

    protected IQueryable<TDto> ProjectToDto<TEntity, TDto>(IQueryable<TEntity> query)
        where TEntity : class
    {
        return query.ProjectTo<TDto>(Mapper.ConfigurationProvider);
    }
}