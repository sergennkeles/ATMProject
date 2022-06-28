using ATMProject.Application.DTOs;
using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Customers
{
    public class UpdateCustomerCommand:IRequest<ServiceResponse<CustomerInfoDto>>
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
