using ECommerseApi.Application.Dtos.ProductDtos;
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
        public IActionResult Get()
        {
            return Ok(_productReadRepository.GetAll(false));

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
             return Ok(await _productReadRepository.GetByIdAsync(id , false));

        }

        [HttpPost]
        public async Task<IActionResult> Post(Product_Create_Dto model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });

            await _productWriteRepository.SaveChangeAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product_Update_Dto model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);

            product.Stock = model.Stock;    
            product.Name = model.Name;
            product.Price = model.Price;

            await _productWriteRepository.SaveChangeAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveByIdAsync(id);

            await _productWriteRepository.SaveChangeAsync();

            return Ok();

        }

    }
}
