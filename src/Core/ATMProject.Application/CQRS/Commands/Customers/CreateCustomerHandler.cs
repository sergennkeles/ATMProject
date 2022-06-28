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

namespace ATMProject.Application.CQRS.Commands.Customers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, ServiceResponse<CustomerInfoDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CreateCustomerHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CustomerInfoDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };

            var addCustomer = await  _customerService.AddAsync(customer);
            var dto = _mapper.Map<CustomerInfoDto>(addCustomer);
            return new ServiceResponse<CustomerInfoDto>(dto,true,"Hesabınız başarıyla oluşturuldu.");
        }
    }
}
