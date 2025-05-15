using Domain.Interfaces;
using Domain.RepoInterfaces;
using Domain.ServiceInterfaces;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class WriteRepository<T>(AppDbContext context) : IWriteRepository<T>
    where T : Entity, IEntity
{
    protected readonly DbSet<T> DbSet = context.Set<T>();

    public async void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }


    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }


    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public async Task DeleteByIdAsync(Guid id) 
    {
        var entity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            DbSet.Remove(entity);
        }
    }
}