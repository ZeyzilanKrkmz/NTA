using NTA.Core.Models;
using NTA.Core.Repositories;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;

namespace NTA.Service.Services;

public class ProductService:Service<Product>,IProductService
{
    public ProductService(IGenericRepository<Product> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
    {
    }
}