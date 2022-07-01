using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Utilities.Security.Hashing;
using ATMProject.Application.Utilities.Security.JWT;
using ATMProject.Application.Wrappers;
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

        public ServiceResponse<Account> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _service.GetByMail(userForLoginDto.Email);
           
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ServiceResponse<Account>("Parolanız yanlış.");

            }
            return new ServiceResponse<Account>(userToCheck,true,"Giriş başarılı");

        }

        public async Task<ServiceResponse<Account>> Register(UserForRegisterDto userForRegisterDto, string password)
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
           await   _service.AddAsync(user);
            return  new ServiceResponse<Account>(user, true, "Hesap oluşturuldu..."); ;
        }
    }
}
