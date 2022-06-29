using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using AutoMapper;
using MediatR;

namespace ATMProject.Application.CQRS.Queries.Customers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ServiceResponse<List<UserInfoDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _service;
        public GetAllUserHandler(IMapper mapper, IAccountService service)
        {
             _mapper = mapper;
            _service = service;
        }


        public async Task<ServiceResponse<List<UserInfoDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _service.GetAllAsync();
            var dto = _mapper.Map<List<UserInfoDto>>(users);


            return new ServiceResponse<List<UserInfoDto>>(dto,true,"Tüm kayıtlar listelendi.");
        }
    }
}
