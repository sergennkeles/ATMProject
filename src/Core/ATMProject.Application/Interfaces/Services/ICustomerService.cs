using ATMProject.Application.DTOs;
using ATMProject.Domain.Common;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Interfaces.Services
{
    public interface ICustomerService: IGenericService<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomerInfoWithCash();
    }
}
