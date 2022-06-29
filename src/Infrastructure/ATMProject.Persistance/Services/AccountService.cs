using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Interfaces.UnitOfWorks;
using ATMProject.Application.Utilities.Security.Hashing;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Services
{
    public class AccountService : GenericService<Account>, IAccountService
    {

        private readonly IAccountRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IGenericRepository<Account> genericRepository, IUnitOfWork unitOfWork, IAccountRepository accountRepository) : base(genericRepository, unitOfWork)
        {
            _userRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OperationClaim>> GetClaims(Account account)
        {
            return _userRepository.GetClaims(account);
        }

        public ServiceResponse<UpdateUserInfoDto> UpdateUserInfo(UpdateUserInfoDto user)
        {
            var updatedUser = _userRepository.Get(x => x.Id == user.Id).FirstOrDefault();
            if (updatedUser == null)
            {
                return new ServiceResponse<UpdateUserInfoDto>("Böyle kullanıcı yok");

            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            updatedUser.FirstName = user.FirstName;
            updatedUser.LastName = user.LastName;
            updatedUser.Email = user.Email;
            updatedUser.PasswordHash = passwordHash;
            updatedUser.PasswordSalt = passwordSalt;
            _userRepository.Update(updatedUser);
            _unitOfWork.SaveChange();
            return new ServiceResponse<UpdateUserInfoDto>("Güncelleme başarılı");
        }
    }
}
