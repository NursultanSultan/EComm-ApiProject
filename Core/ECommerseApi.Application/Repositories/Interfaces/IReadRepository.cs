using ECommerseApi.Domain.Entities.Common;

using System.Linq.Expressions;

namespace ECommerseApi.Application.Repositories.Interfaces
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T,bool>> method , bool tracking = true);

        Task<T> GetOneWhereAsync(Expression<Func<T, bool>> method , bool tracking = true);

        Task<T> GetByIdAsync(string id , bool tracking = true);
    }
}
