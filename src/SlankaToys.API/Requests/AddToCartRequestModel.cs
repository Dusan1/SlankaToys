using System;
namespace SlankaToys.API.Requests
{
    public class AddToCartRequestModel
    {
        public AddToCartRequestModel()
        {
        
        }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
