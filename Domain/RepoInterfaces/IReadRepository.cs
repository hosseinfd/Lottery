using Domain.ServiceInterfaces;
using Domain.Services;

namespace Domain.RepoInterfaces;

public interface IReadRepository<T> where T : Entity,IEntity
{
    Task<T?> GetByIdAsync(Guid id,CancellationToken cancellationToken = default);           
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);    
    

}