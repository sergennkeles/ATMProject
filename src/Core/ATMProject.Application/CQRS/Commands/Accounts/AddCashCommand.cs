using ATMProject.Application.DTOs;
using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Accounts
{
    public class AddCashCommand:IRequest<ServiceResponse<CashAddDto>>
    {
        public int Id { get; set; }
        public decimal Cash { get; set; }
    }
}
