using NTA.Core.Models;

namespace NTA.Core.Repositories.Repositories;

public class DepartmentRepository(AppDbContext context):GenericRepository<Department>(context),IDepartmentRepository
{
    
}