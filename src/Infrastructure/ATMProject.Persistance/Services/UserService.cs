using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Interfaces.UnitOfWorks;
using ATMProject.Application.Utilities.Security.Hashing;
using ATMProject.Application.Wrappers;
using ATMProject.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Services
{
    public class UserService : GenericService<User>, IUserService
    {

        public UserService(IGenericRepository<User> genericRepository, IUnitOfWork unitOfWork, IUserRepository customerRepository, IMapper mapper) : base(genericRepository, unitOfWork)
        {
           
        }

 

      
    }
}
