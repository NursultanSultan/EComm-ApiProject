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
        Task<bool> AddRangeAsync(List<T> entities);

        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        Task<bool> RemoveByIdAsync(string Id);

        bool Update(T entity);

        Task SaveChangeAsync();
    }
    
}
