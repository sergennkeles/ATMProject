using ATMProject.Application.DTOs;
using ATMProject.Application.Utilities.Security.JWT;
using ATMProject.Domain.Common;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Account> Register(UserForRegisterDto userForRegisterDto,string password);
        Task<Account> Login(UserForLoginDto userForLoginDto);
        Task<AccessToken> CreateAccessToken(Account account);
    }
}
