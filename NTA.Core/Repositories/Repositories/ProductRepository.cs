using NTA.Core.Models;

namespace NTA.Core.Repositories.Repositories;

public class ProductRepository(AppDbContext context):GenericRepository<Product>(context),IProductRepository
{
    
}