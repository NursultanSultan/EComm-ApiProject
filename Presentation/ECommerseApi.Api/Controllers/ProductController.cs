using ECommerseApi.Application.Repositories.Interfaces.ProductEntity;
using ECommerseApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerseApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new(){Id = Guid.NewGuid(),Name = "Salam",Price=999,Stock=10  , CreatedDate = DateTime.UtcNow},
            //    new(){Id = Guid.NewGuid(),Name = "Aleykum",Price=888,Stock=20  , CreatedDate = DateTime.UtcNow}
            //});

            //Product pr = await _productReadRepository.GetByIdAsync("eee6b33e-1be1-48ab-9175-df9cf07be09f",false);
            //pr.Name = "Alalala";
            //await _productWriteRepository.SaveChangeAsync();
        }
    }
}
