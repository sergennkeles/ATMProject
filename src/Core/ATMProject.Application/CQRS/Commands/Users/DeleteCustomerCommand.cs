using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Customers
{
    public class DeleteCustomerCommand:IRequest<ServiceResponse<ServiceResponseNoData>>
    {
        public int Id { get; set; }
    }
}
