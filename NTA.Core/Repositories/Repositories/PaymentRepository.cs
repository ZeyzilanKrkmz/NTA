using NTA.Core.Models;

namespace NTA.Core.Repositories.Repositories;

public class PaymentRepository(AppDbContext context):GenericRepository<Payment>(context),IPaymentRepository
{
    
}