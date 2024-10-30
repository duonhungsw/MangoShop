using Common.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mango.Service.CartAPI.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly CartDbContext _context;

    public GenericRepository(CartDbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public bool Exist(Guid id)
    {
        return _context.Set<T>().Any(x => x.Id.Equals(id));
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>>? includeQuery = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includeQuery != null)
        {
            query = includeQuery(query);
        }

        return await query.ToListAsync();
    }


    public Task<T?> GetByIdAsync(Guid id)
    {
        return _context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
    public async Task<T?> GetObject<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

}

