using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Auths
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, ServiceResponse<ServiceResponseNoData>>
    {

        private readonly IAuthService _authService;

        public RegisterHandler(IAuthService authService)
        {
            _authService = authService;
        }

        async Task<ServiceResponse<ServiceResponseNoData>> IRequestHandler<RegisterCommand, ServiceResponse<ServiceResponseNoData>>.Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerUser = _authService.Register(request.RegisterDto, request.RegisterDto.Password);
            _authService.CreateAccessToken(registerUser.Result);
            return new ServiceResponse<ServiceResponseNoData>("Hesap oluşturuldu.");
        }
    }
}
