using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using AutoMapper;
using MediatR;

namespace ATMProject.Application.CQRS.Queries.Customers
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, ServiceResponse<List<CustomerInfoDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        public GetAllCustomerHandler(IMapper mapper, ICustomerService customerService)
        {
             _mapper = mapper;
            _customerService = customerService;
        }


        public async Task<ServiceResponse<List<CustomerInfoDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetAllAsync();
            var dto = _mapper.Map<List<CustomerInfoDto>>(customers);


            return new ServiceResponse<List<CustomerInfoDto>>(dto,true,"Tüm kayıtlar listelendi.");
        }
    }
}
