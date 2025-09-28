using NTA.Core.Models;
using NTA.Core.Repositories;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;

namespace NTA.Service.Services;

public class CustomerService:Service<Customer>,ICustomerService
{
    private static ICustomerRepository customerRepository;
    private readonly ICustomerRepository _customerRepository=customerRepository;
    public CustomerService(IGenericRepository<Customer> repository, IUnitOfWorks unitOfWorks, ICustomerRepository customerRepository) : base(repository, unitOfWorks)
    {

        
    }
}