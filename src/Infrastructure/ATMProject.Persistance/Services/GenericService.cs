using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Application.Interfaces.UnitOfWorks;
using ATMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GenericService(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
            return  entity ;
        }


        public async Task DeleteAsync(T entity)
        {
             _genericRepository.Delete(entity);
             await _unitOfWork.SaveChangeAsync(); 
             
        }

        public async Task<List<T>> GetAllAsync()
        {
          return await _genericRepository.GetAllAsync();
            
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _genericRepository.Update(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
         {
            return _genericRepository.Get(predicate);
        }
    }
}
