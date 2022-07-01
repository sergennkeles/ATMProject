using ATMProject.Application.DTOs;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Common;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Interfaces.Services
{
    public  interface IAccountService:IGenericService<Account>
    {
        Task<List<OperationClaim>> GetClaims(Account account);
        ServiceResponse<UpdateUserInfoDto> UpdateUserInfo(UpdateUserInfoDto user);
        Account GetByMail(string mail);
        ServiceResponse<AccountInfoDto> WithDrawMoney(AccountInfoDto account,decimal money);
    }
}

