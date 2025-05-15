using Domain.ServiceInterfaces;
using Domain.Services;

namespace Domain.RepoInterfaces;

public interface IWriteRepository<T> where T : Entity, IEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task DeleteByIdAsync(Guid id);
}