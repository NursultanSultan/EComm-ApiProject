

namespace ECommerseApi.Application.Dtos.ProductDtos
{
    public class Product_Update_Dto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
