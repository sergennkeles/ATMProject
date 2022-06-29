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
    public class AddCashHandler : IRequestHandler<AddCashCommand, ServiceResponse<CashAddDto>>
    {
        private readonly IAccountService _accountService;

        public AddCashHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ServiceResponse<CashAddDto>> Handle(AddCashCommand request, CancellationToken cancellationToken)
        {

          var account= _accountService.Get(x => x.Id== request.Id).FirstOrDefault();
           
            if (account == null)
            {
                return new ServiceResponse<CashAddDto>("Böyle bir hesap  bilgisi yok.");
            }
             account.Cash=request.Cash; 
        
            
            await _accountService.UpdateAsync(account);
            return new ServiceResponse<CashAddDto> ("Hesabınıza para yatırılmıştır.");
        }
    }
}
