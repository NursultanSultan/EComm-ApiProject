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
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
