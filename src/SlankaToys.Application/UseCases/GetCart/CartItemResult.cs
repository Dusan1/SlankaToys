using System;
namespace SlankaToys.Application.UseCases.GetCart
{
    public class CartItemResult
    {
        public CartItemResult()
        {
        }

        public string  ProductName { get; set; }
        public int  ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageFileName { get; set; }
    }
}
