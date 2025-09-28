using System.Linq.Expressions;

namespace NTA.Core.Repositories;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<T> GetByIdAsync(int id);
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    int Count();

    void Update(T entity);
    void ChangeStatus(T entity);
    Task AddAsync(T entity);

    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);



}