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
    public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, ServiceResponse<UserInfoDto>>
    {

        private readonly IAccountService _userService;
        private readonly IMapper _mapper;

        public GetByIdUserHandler(IAccountService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

  
        public async Task<ServiceResponse<UserInfoDto>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var customer= _userService.Get(x=>x.Id==request.Id).FirstOrDefault();
            if (customer==null)
            { 
                return new ServiceResponse<UserInfoDto>("Böyle bir kullanıcı yok");

            }
            var dto =  _mapper.Map<UserInfoDto>(customer);
            return  new ServiceResponse<UserInfoDto>(dto,true,"Kayıt başarıyla getirildi.");
        }
    }
}
