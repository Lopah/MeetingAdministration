﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingAdministration.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public Task<T> UpdateAsync(T entity);

        Task<IList<T>> GetAllAsync();
    }
}
