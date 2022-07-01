using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Wrappers;
using AutoMapper;
using MediatR;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Utilities.Security.Hashing;

namespace ATMProject.Application.CQRS.Commands.Customers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, ServiceResponse<UserInfoDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _customerService;

        public CreateCustomerHandler(IAccountService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserInfoDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            var customer = new Account
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt
            
            };

            var addCustomer = await  _customerService.AddAsync(customer);
            var dto = _mapper.Map<UserInfoDto>(addCustomer);
            return new ServiceResponse<UserInfoDto>(dto,true,"Hesabınız başarıyla oluşturuldu.");
        }
    }
}
