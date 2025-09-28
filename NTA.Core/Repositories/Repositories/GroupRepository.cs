using NTA.Core.Models;

namespace NTA.Core.Repositories.Repositories;

public class GroupRepository(AppDbContext context):GenericRepository<Group>(context),IGroupRepository
{
    
}