using NTA.Core.Models;
using NTA.Core.Repositories;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;

namespace NTA.Service.Services;

public class SaleService:Service<Sale>,ISaleService
{
    public SaleService(IGenericRepository<Sale> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
    {
    }
}