namespace Shop.Infrastructure.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);

    Task<List<T>> GetAllAsync();

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task SaveChangesAsync();
}