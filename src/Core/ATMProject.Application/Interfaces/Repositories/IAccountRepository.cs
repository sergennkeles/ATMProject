using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Interfaces.Repositories
{
    public interface IAccountRepository:IGenericRepository<Account>
    {
        List<OperationClaim> GetClaims(Account account);
 
    }
}
