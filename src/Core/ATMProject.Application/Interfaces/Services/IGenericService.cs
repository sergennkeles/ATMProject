﻿using ATMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Interfaces.Services
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
