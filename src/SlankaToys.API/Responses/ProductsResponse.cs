using System;
namespace SlankaToys.API.Responses
{
    public class ProductsResponse
    {
        public ProductsResponse()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageFileName { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
    }
}
