using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Domain.RepoInterfaces;
using Domain.ServiceInterfaces;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ReadRepository<T>(AppDbContext context) : IReadRepository<T>
    where T : Entity,IEntity
{
    public async Task<T?> GetByIdAsync(Guid id,CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FirstOrDefaultAsync(x=> x.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct= default)
    {
        return await context.Set<T>().ToListAsync(default);
    }
    
    // protected IQueryable<TDto> ProjectToDto<TEntity, TDto>(IQueryable<TEntity> query)
    //     where TEntity : class
    // {
    //     return query.ProjectTo<TDto>(mapper.ConfigurationProvider);
    // }
}