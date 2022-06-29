using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Utilities.Security.Hashing;
using ATMProject.Application.Utilities.Security.JWT;
using ATMProject.Domain.Common;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Services
{
    public class AuthService : IAuthService

    {
        private readonly IAccountService _service;
         private readonly ITokenHelper _tokenHelper;
        public AuthService(IAccountService service, ITokenHelper tokenHelper)
        {
            _service = service;
            _tokenHelper = tokenHelper;
        }

        public  Task<AccessToken> CreateAccessToken(Account account)
        {
            var claims = _service.GetClaims(account);
            var token = _tokenHelper.CreateToken(account, claims.Result);
            return Task.FromResult(token);
        }

        public async Task<Account> Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new Account
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
           
            };
           await _service.AddAsync(user);
            return user;
        }
    }
}
