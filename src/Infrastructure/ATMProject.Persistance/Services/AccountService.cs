using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Interfaces.UnitOfWorks;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Services
{
    public class AccountService : GenericService<Account>, IAccountService
    {
        public AccountService(IGenericRepository<Account> genericRepository, IUnitOfWork unitOfWork) : base(genericRepository, unitOfWork)
        {
        }
    }
}
