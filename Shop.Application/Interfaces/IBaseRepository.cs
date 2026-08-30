using System.Linq.Expressions;

namespace Shop.Infrastructure.Repositories


{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>>? GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>?, IOrderedQueryable<T>>? orderBy = null,
                                        string? includeString = null,
                                        bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                       Func<IQueryable<T>?, IOrderedQueryable<T>>? orderBy = null,
                                       List<Expression<Func<T, object>>>? includes = null,
                                       bool disableTracking = true);
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T?> GetOneAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> Add(T entity);
        Task UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<int> SaveChangeAsync();
        IQueryable<T> AsQueryable();
        Task ExecuteTransactionAsync(Func<Task> action);
        Task<T?> GetByEntityFirstAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetByEntityListAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetLastRowAsync(Expression<Func<T, object>> orderByKey, CancellationToken cancellationToken = default);
        Task<T?> GetByEntityAsNoTrackingFirstAsync(Expression<Func<T, bool>> predicate);
        Task<T?> UpdateByEntityFirstAsync(Expression<Func<T, bool>> predicate, Action<T> updateAction);
    }
}
