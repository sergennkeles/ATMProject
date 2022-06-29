using ATMProject.Application.DTOs;
using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Auths
{
    public class RegisterCommand:IRequest<ServiceResponse<ServiceResponseNoData>>
    {
        public UserForRegisterDto RegisterDto { get; set; }
    }

    
}
