using NTA.Core.Models;
using NTA.Core.Repositories;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;

namespace NTA.Service.Services;

public class DepartmentService:Service<Department>,IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    public DepartmentService(IGenericRepository<Department> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
    {
        _departmentRepository = _departmentRepository;
    }
}