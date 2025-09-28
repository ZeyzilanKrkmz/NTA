using NTA.Core.Models;

namespace NTA.Core.Repositories;

public interface ICustomerRepository:IGenericRepository<Customer>
{
    List<Customer> GetCustomersWithBalance(int balance);
    
}