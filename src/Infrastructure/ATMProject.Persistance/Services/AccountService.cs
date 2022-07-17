using ATMProject.Application.DTOs;
using ATMProject.Application.Exceptions;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Interfaces.UnitOfWorks;
using ATMProject.Application.Utilities.Security.Hashing;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Entities;
using AutoMapper;

namespace ATMProject.Persistance.Services
{
    public class AccountService : GenericService<Account>, IAccountService
    {


        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IGenericRepository<Account> genericRepository, IUnitOfWork unitOfWork, IAccountRepository accountRepository, IMapper mapper) : base(genericRepository, unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceResponse<Account> GetByMail(string mail) 
        {
            var account = _accountRepository.Get(x => x.Email == mail).FirstOrDefault() ;

            if (account == null)
            {
               return new ServiceResponse<Account>("Böyle bir kullanıcı yok.");// BURAYA TEKRAR BAK! Login kısmında problem var!
            }
            return new ServiceResponse<Account>(account,true,"");
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

        public  ServiceResponse<AccountInfoDto> WithDrawMoney(AccountInfoDto account,decimal money)
        {
            var accountInfo =  _accountRepository.Get(x => x.Id ==  account.Id).FirstOrDefault();
            if (accountInfo.Cash<money)
            {
                return new ServiceResponse<AccountInfoDto>("Bakiyeniz yetersiz!"); ;

            }

            var cashCount = accountInfo.Cash - money;
            accountInfo.Cash=cashCount;
            var dto = _mapper.Map<AccountInfoDto>(accountInfo);
            _accountRepository.Update(accountInfo);
            _unitOfWork.SaveChange();
            return  new ServiceResponse<AccountInfoDto>(dto,true,"Hesabınızdan para çekilmiştir.");

        }
    }
}
