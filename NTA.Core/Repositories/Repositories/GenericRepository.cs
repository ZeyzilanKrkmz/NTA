using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NTA.Core.Models;

namespace NTA.Core.Repositories.Repositories;

public class GenericRepository<T>:IGenericRepository<T> where T:BaseEntity
{

    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }


    public IQueryable<T> GetAll()
    {
        return _dbSet.Where(x => x.Status).AsQueryable();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(x => x.Status == true).AsQueryable();
    }

    public int Count()
    {
        return _dbSet.Count();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void ChangeStatus(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }
}