using Common.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>>? includeQuery = null);
     void Delete(T entity);
    void Update(T entity);
    void Create(T entity);
    bool Exist(Guid id);
    Task<T?> GetObject<T>(Expression<Func<T, bool>> predicate) where T : class;
}


