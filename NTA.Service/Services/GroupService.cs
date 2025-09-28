using System.Linq.Expressions;
using NTA.Core.Repositories;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;
using NTA.Core.Models; // Group modeliniz buradaysa

namespace NTA.Service.Services;

public class GroupService : Service<Group>, IGroupService
{
    public GroupService(IGenericRepository<Group> repository, IUnitOfWorks unitOfWorks) 
        : base(repository, unitOfWorks)
    {
    }

    public IQueryable<Group> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<Group> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public IQueryable<Group> Where(Expression<Func<Group, bool>> expression)
    {
        return _repository.Where(expression);
    }

    public int Count()
    {
        return _repository.Count();
    }

    public void Update(Group entity)
    {
        _repository.Update(entity);
    }

    public void ChangeStatus(Group entity)
    {
        // Buraya kendi mantığınızı ekleyin, örneğin aktiflik toggle etmek:
        //entity.IsActive = !entity.IsActive;
        _repository.Update(entity);
    }

    public async Task AddAsync(Group entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<Group, bool>> expression)
    {
        return await _repository.AnyAsync(expression);
    }
}