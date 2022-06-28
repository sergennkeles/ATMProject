using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Domain.Entities;
using ATMProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public  IQueryable<Customer> GetCustomerInfoWithCash()
        {
            return  _context.Set<Customer>().Include(x => x.Accounts).AsNoTracking().AsQueryable();
        }
    }
}
