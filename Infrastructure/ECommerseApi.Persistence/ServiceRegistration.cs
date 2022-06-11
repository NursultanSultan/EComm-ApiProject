using ECommerseApi.Application.Repositories.Interfaces.CustomerEntity;
using ECommerseApi.Application.Repositories.Interfaces.OrderEntity;
using ECommerseApi.Application.Repositories.Interfaces.ProductEntity;
using ECommerseApi.Persistence.Contexts;
using ECommerseApi.Persistence.Repositories.Implementation.CustomerEntity;
using ECommerseApi.Persistence.Repositories.Implementation.OrderEntity;
using ECommerseApi.Persistence.Repositories.Implementation.ProductEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerseApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<ApiDbContext>(options => options.UseNpgsql(Configuration.ConnectionString) , ServiceLifetime.Singleton);
            
            service.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            service.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            service.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            service.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            service.AddSingleton<IProductReadRepository, ProductReadRepository>();
            service.AddSingleton<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
