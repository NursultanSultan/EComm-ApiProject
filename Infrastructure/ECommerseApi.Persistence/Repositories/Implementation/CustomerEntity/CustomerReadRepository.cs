using ECommerseApi.Application.Repositories.Interfaces.CustomerEntity;
using ECommerseApi.Domain.Entities;
using ECommerseApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerseApi.Persistence.Repositories.Implementation.CustomerEntity
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
