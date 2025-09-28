using NTA.Core.Models;

namespace NTA.Core.Repositories.Repositories;

public class CustomerRepository(AppDbContext context):GenericRepository<Customer>(context),ICustomerRepository
{
    public List<Customer> GetCustomersWithBalance(int balance)
    {
        throw new NotImplementedException();
    }
}