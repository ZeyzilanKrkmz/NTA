using NTA.Core.Models;
using NTA.Core.Repositories;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;

namespace NTA.Service.Services;

public class PaymentService:Service<Payment>,IPaymentService
{
    public PaymentService(IGenericRepository<Payment> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
    {
    }
}