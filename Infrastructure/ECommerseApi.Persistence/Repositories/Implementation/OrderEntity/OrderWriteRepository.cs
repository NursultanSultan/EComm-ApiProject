using ECommerseApi.Application.Repositories.Interfaces.OrderEntity;
using ECommerseApi.Domain.Entities;
using ECommerseApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerseApi.Persistence.Repositories.Implementation.OrderEntity
{
    internal class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
