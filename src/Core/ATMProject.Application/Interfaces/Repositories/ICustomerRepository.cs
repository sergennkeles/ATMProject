using ATMProject.Domain.Entities;

namespace ATMProject.Application.Interfaces.Repositories
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
       IQueryable<Customer> GetCustomerInfoWithCash();
    }
}
