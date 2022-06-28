using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Domain.Entities;
using ATMProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Repositories
{
    public class BankRepository : GenericRepository<Bank>,IBankRepository
    {
        public BankRepository(AppDbContext context) : base(context)
        {
        }
    }
}
