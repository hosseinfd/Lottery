namespace Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id); // For read operation (Query)
    Task<IEnumerable<T>> GetAllAsync(); // For read operation (Query)
    Task AddAsync(T entity); // For write operation (Command)
    Task UpdateAsync(T entity); // For write operation (Command)
    Task DeleteAsync(Guid id); // For write operation (Command)
}