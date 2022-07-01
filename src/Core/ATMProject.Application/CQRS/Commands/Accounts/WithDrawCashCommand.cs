using ATMProject.Application.DTOs;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Accounts
{
    public class WithDrawCashCommand:IRequest<ServiceResponse<AccountInfoDto>>
    {
        public  AccountInfoDto AccountInfoDto { get; set; }
   
    }
}
