using ATMProject.Application.Exceptions;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Customers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, ServiceResponse<ServiceResponseNoData>>
    {

        private readonly IAccountService _customerService;

        public DeleteCustomerHandler(IAccountService customerService)
        {
            _customerService = customerService;
        }

        async Task<ServiceResponse<ServiceResponseNoData>> IRequestHandler<DeleteCustomerCommand, ServiceResponse<ServiceResponseNoData>>.Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerService.Get(x => x.Id == request.Id).FirstOrDefault();
            if (customer == null)
            {
                return new ServiceResponse<ServiceResponseNoData>("Böyle bir kullanıcı yok.");

            }
           await  _customerService.DeleteAsync(customer);
            return new ServiceResponse<ServiceResponseNoData>("Hesap silinmiştir.");

        }
    }
}
