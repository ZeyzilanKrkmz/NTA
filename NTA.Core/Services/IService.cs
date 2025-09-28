using System.Linq.Expressions;

namespace NTA.Core.Services;

public interface IService<T> where T :class
{
    IQueryable<T> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    int Count();

    void Update(T entity);
    void ChangeStatus(T entity);
    Task<T> AddAsync(T entity);

    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}