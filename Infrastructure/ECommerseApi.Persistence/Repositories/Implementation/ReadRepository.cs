using ECommerseApi.Application.Repositories.Interfaces;
using ECommerseApi.Domain.Entities.Common;
using ECommerseApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerseApi.Persistence.Repositories.Implementation
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ApiDbContext _dbContext;

        public ReadRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            return GetQuery(query , tracking);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            var newQuery = GetQuery(query, tracking);

            return await newQuery.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
             


        public async Task<T> GetOneWhereAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            var newQuery = GetQuery(query, tracking);

            return await newQuery.FirstOrDefaultAsync(method);
        }
            


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            return GetQuery(query , tracking);
        }
        

        public IQueryable<T> GetQuery(IQueryable<T> query , bool tracking)
        {
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
    }
}
