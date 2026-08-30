using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Data;
using System.Linq.Expressions;

namespace Shop.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DbContext _context;
    public BaseRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        //await _context.SaveChangesAsync();  
        return entity;
    }

    public Task<T> Add(T entity)
    {
        _context.Set<T>().Add(entity);
        return Task.FromResult(entity);
    }

    public async Task<List<T>> AddRangeAsync(List<T> entity)
    {
        await _context.Set<T>().AddRangeAsync(entity);
        //await _ctx.SaveChangesAsync();
        return entity;
    }
    public Task<T> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return Task.FromResult(entity);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {

        return await _context.Set<T>().ToListAsync();
    }

    public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeString = null, bool disableTracking = true)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(id, cancellationToken);
    }
    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(id, cancellationToken);
    }
    public async Task<T?> GetOneAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }
    public IQueryable<T> AsQueryable()
    {
        return _context.Set<T>().AsQueryable();
    }
    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task ExecuteTransactionAsync(Func<Task> action)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            await action();
            await transaction.CommitAsync();
        });
    }

    public async Task<T?> GetByEntityFirstAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }
    public async Task<T?> GetLastRowAsync(Expression<Func<T, object>> orderByKey, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>()
                        .OrderByDescending(orderByKey)
                        .FirstOrDefaultAsync(cancellationToken);

    }
    public async Task<List<T>> GetByEntityListAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new List<T>();
        }
    }
    public async Task<T?> GetByEntityAsNoTrackingFirstAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
    }
    public async Task<T?> UpdateByEntityFirstAsync(Expression<Func<T, bool>> predicate, Action<T> updateAction)
    {
        var entity = await _context.Set<T>()
     .FirstOrDefaultAsync(predicate);

        if (entity == null)
            return null;

        updateAction(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}