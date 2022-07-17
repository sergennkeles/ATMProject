using ATMProject.Application.DTOs;
using ATMProject.Application.Utilities.Security.JWT;
using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Auths
{
    public class LoginCommand:IRequest<ServiceResponse<AccessToken>>
    {
        public UserForLoginDto Login { get; set; }
    }
}
