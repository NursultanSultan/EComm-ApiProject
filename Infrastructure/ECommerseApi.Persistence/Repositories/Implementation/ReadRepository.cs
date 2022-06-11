using ECommerseApi.Application.Repositories.Interfaces;
using ECommerseApi.Domain.Entities.Common;
using ECommerseApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerseApi.Persistence.Repositories.Implementation
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        public readonly ApiDbContext _dbContext;

        public ReadRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetByIdAsync(string id)
            => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));


        public async Task<T> GetOneWhereAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);
        
    }
}
