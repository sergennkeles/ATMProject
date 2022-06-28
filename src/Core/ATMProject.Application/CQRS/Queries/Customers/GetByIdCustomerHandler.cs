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
    public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerQuery, ServiceResponse<CustomerInfoDto>>
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public GetByIdCustomerHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<CustomerInfoDto>> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer= _customerService.Get(x=>x.Id==request.Id).FirstOrDefault();
            if (customer==null)
            { 
                return new ServiceResponse<CustomerInfoDto>("Böyle bir kullanıcı yok");

            }
            var dto =  _mapper.Map<CustomerInfoDto>(customer);
            return  new ServiceResponse<CustomerInfoDto>(dto,true,"Kayıt başarıyla getirildi.");
        }
    }
}
