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
    internal class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
