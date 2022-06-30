using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Interfaces.UnitOfWorks;
using ATMProject.Application.Utilities.Security.Hashing;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Entities;

namespace ATMProject.Persistance.Services
{
    public class AccountService : GenericService<Account>, IAccountService
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IGenericRepository<Account> genericRepository, IUnitOfWork unitOfWork, IAccountRepository accountRepository) : base(genericRepository, unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public Account GetByMail(string mail)
        {
            return _accountRepository.Get(x => x.Email == mail).FirstOrDefault();
        }

        public async Task<List<OperationClaim>> GetClaims(Account account)
        {
            return _accountRepository.GetClaims(account);
        }
     
        public ServiceResponse<UpdateUserInfoDto> UpdateUserInfo(UpdateUserInfoDto user)
        {
            var updatedUser = _accountRepository.Get(x => x.Id == user.Id).FirstOrDefault();
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
            _accountRepository.Update(updatedUser);
            _unitOfWork.SaveChange();
            return new ServiceResponse<UpdateUserInfoDto>("Güncelleme başarılı");
        }
    }
}
