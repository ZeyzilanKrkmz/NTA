using System.Linq.Expressions;
using NTA.Core.Models;
using NTA.Core.Repositories;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;

namespace NTA.Service.Services;

public class Service<T>:IService<T> where T : BaseEntity
{

    protected readonly IGenericRepository<T> _repository;
    protected readonly IUnitOfWorks _unitOfWorks;

    public Service(IGenericRepository<T> repository, IUnitOfWorks unitOfWorks)
    {
        _repository = repository;
        _unitOfWorks = unitOfWorks;
    }
    
    
    
    public IQueryable<T> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _repository.Where(expression);
    }

    public int Count()
    {
        return _repository.Count();
    }

    public async void Update(T entity)
    {
        _repository.Update(entity);
        _unitOfWorks.Commit();
    }

    public void ChangeStatus(T entity)
    {
        entity.UpdatedDate = DateTime.Now;
        _repository.ChangeStatus(entity);
        _unitOfWorks.Commit();
    }

    public virtual async Task AddAsync(T entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.UpdatedDate = DateTime.Now;
       await _repository.AddAsync(entity);
       await _unitOfWorks.CommitAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _repository.AnyAsync(expression);
    }
}