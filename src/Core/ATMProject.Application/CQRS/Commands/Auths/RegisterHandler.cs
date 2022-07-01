using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using AutoMapper;
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

        public async Task<ServiceResponse<ServiceResponseNoData>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerUser = await _authService.Register(request.RegisterDto, request.RegisterDto.Password);

           await  _authService.CreateAccessToken(registerUser.Data);
            return new ServiceResponse<ServiceResponseNoData>("Hesap oluşturuldu.");
        }


     
    }
}
