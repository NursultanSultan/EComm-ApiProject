using ECommerseApi.Application.Repositories.Interfaces;
using ECommerseApi.Domain.Entities.Common;
using ECommerseApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ECommerseApi.Persistence.Repositories.Implementation
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        public readonly ApiDbContext _dbContext;

        public WriteRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();


        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<bool> RemoveByIdAsync(string Id)
        {
            T entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(Id));
            return Remove(entity);
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
