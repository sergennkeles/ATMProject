using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Services;
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
    public class LoginHandler : IRequestHandler<LoginCommand, ServiceResponse<AccessToken>>
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ServiceResponse<AccessToken>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginUser = _authService.Login(request.Login);

            if (!loginUser.Success)
            {
                return new ServiceResponse<AccessToken>(loginUser.Message);

            }
            var token = await _authService.CreateAccessToken(loginUser.Data);

            return new ServiceResponse<AccessToken>(token,true,"Token oluşturuldu.");
        }
    }
}
