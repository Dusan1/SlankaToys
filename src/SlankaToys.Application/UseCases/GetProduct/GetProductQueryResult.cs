using System;
namespace SlankaToys.Application.UseCases.GetProduct
{
    public class GetProductQueryResult
    {
        public GetProductQueryResult()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
    }
}
