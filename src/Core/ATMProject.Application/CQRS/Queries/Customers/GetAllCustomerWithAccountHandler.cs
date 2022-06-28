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

namespace ATMProject.Application.CQRS.Queries.Customers
{
    public class GetAllCustomerWithAccountHandler : IRequestHandler<GetAllCustomerWithAccountQuery, ServiceResponse<List<CustomerInfoWithAccountDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        public GetAllCustomerWithAccountHandler(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }
        public async Task<ServiceResponse<List<CustomerInfoWithAccountDto>>> Handle(GetAllCustomerWithAccountQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetCustomerInfoWithCash();
            var dto = _mapper.Map<List<CustomerInfoWithAccountDto>>(customers);


            return new ServiceResponse<List<CustomerInfoWithAccountDto>>(dto, true, "Tüm kayıtlar listelendi.");
        }
    }
}
