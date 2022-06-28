using ATMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Get(Expression<Func<T,bool>> predicate);
        Task<T> AddAsync(T entity);
        void Update (T entity);
        void Delete (T entity);
    }
}
