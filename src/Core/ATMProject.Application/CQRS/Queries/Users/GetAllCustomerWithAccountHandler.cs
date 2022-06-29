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
    public class GetAllCustomerWithAccountHandler : IRequestHandler<GetAllCustomerWithAccountQuery, ServiceResponse<List<UserInfoWithAccountDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _service;
        public GetAllCustomerWithAccountHandler(IMapper mapper, IAccountService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<ServiceResponse<List<UserInfoWithAccountDto>>> Handle(GetAllCustomerWithAccountQuery request, CancellationToken cancellationToken)
        {
            var customers = await _service.GetAllAsync();
            var dto = _mapper.Map<List<UserInfoWithAccountDto>>(customers);


            return new ServiceResponse<List<UserInfoWithAccountDto>>(dto, true, "Tüm kayıtlar listelendi.");
        }
    }
}
