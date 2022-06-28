using ATMProject.Application.DTOs;
using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Interfaces.UnitOfWorks;
using ATMProject.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Services
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> genericRepository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper) : base(genericRepository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> GetCustomerInfoWithCash()
        {
            var customer =  _customerRepository.GetCustomerInfoWithCash();
            return  customer; 
        }
    }
}
