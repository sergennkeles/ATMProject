using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Customers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, ServiceResponse<CustomerInfoDto>>
    {
        private readonly ICustomerService _customerService;


        public UpdateCustomerHandler( ICustomerService customerService)
        {
                _customerService = customerService;
        }

        public async Task<ServiceResponse<CustomerInfoDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerService.Get(x => x.Id == request.Id).FirstOrDefault();
            if (customer == null)
            {
                return new ServiceResponse<CustomerInfoDto>("Böyle bir kullanıcı yok");

            }
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Email = request.Email;
            customer.Password = request.Password;
          
            _customerService.UpdateAsync(customer);
            return new ServiceResponse<CustomerInfoDto>("Bilgileriniz başarıyla güncellenmiştir.");
        }
    }
}
