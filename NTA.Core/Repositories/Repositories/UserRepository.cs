using NTA.Core.Models;

namespace NTA.Core.Repositories.Repositories;

public class UserRepository(AppDbContext context):GenericRepository<User>(context),IUserRepository
{
    
}