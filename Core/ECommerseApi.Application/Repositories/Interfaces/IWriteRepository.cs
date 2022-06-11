using ECommerseApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerseApi.Application.Repositories.Interfaces
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity 
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(List<T> entities);

        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveByIdAsync(string Id);

        Task<bool> UpdateAsync(T entity);
    }
    
}
