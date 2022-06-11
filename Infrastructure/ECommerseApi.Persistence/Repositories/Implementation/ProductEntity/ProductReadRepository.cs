using ECommerseApi.Application.Repositories.Interfaces.ProductEntity;
using ECommerseApi.Domain.Entities;
using ECommerseApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerseApi.Persistence.Repositories.Implementation.ProductEntity
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
