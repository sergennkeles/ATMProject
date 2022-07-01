using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Accounts
{
    public class WithDrawCashHandler : IRequestHandler<WithDrawCashCommand, ServiceResponse<AccountInfoDto>>
    {

        private readonly IAccountService _accountService;

        public WithDrawCashHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ServiceResponse<AccountInfoDto>> Handle(WithDrawCashCommand request, CancellationToken cancellationToken)
        {

            var account = _accountService.Get(x => x.Id == request.AccountInfoDto.Id).FirstOrDefault();

            if (account == null)
            {
                return new ServiceResponse<AccountInfoDto>("Böyle bir hesap  bilgisi yok.");
            }
           var dto=  _accountService.WithDrawMoney(request.AccountInfoDto,request.AccountInfoDto.Cash);


            return new ServiceResponse<AccountInfoDto>(dto.Data,false,dto.Message);
        }
    }
}
