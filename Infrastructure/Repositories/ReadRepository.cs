using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class
{
    private readonly AppDbContext _context;
    protected readonly IMapper Mapper;

    public ReadRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        Mapper = mapper;
    }

    public async Task<T?> GetByIdAsync(Guid id,CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(new object?[] { id, cancellationToken }, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct= default)
    {
        return await _context.Set<T>().ToListAsync(default);
    }
    
    protected IQueryable<TDto> ProjectToDto<TEntity, TDto>(IQueryable<TEntity> query)
        where TEntity : class
    {
        return query.ProjectTo<TDto>(Mapper.ConfigurationProvider);
    }
}