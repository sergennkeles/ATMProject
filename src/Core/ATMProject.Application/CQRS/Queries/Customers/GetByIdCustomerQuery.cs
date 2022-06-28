using ATMProject.Application.DTOs;
using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Queries.Customers
{
    public class GetByIdCustomerQuery:IRequest<ServiceResponse<CustomerInfoDto>>
    {
        public int Id { get; set; }
    }
}
