using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.CQRS.Commands.Accounts
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, ServiceResponse<ServiceResponseNoData>>
    {

        private readonly IAccountService _accountService;

        public CreateAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ServiceResponse<ServiceResponseNoData>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account=new Account { CustomerId = request.CustomerId ,Cash=request.Cash};
            await _accountService.AddAsync(account);
            return new ServiceResponse<ServiceResponseNoData>("Kayıt başarılı.");
        }
    }
}
