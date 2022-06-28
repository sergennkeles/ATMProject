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

namespace ATMProject.Application.CQRS.Queries.Acounts
{
    public class GetAllAccountHandler : IRequestHandler<GetAllAccountQuery, ServiceResponse<List<AccountInfoDto>>>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public GetAllAccountHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<AccountInfoDto>>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountService.GetAllAsync();
            var dto = _mapper.Map<List<AccountInfoDto>>(accounts);
            return new ServiceResponse<List<AccountInfoDto>>(dto, true, "Tüm kayıtlar listelendi.");
        }
    }
}
