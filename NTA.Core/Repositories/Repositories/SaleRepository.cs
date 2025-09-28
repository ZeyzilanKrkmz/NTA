using NTA.Core.Models;

namespace NTA.Core.Repositories.Repositories;

public class SaleRepository(AppDbContext context):GenericRepository<Sale>(context),ISaleRepository
{
    
}