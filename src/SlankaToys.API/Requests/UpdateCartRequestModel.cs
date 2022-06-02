using System;

namespace SlankaToys.API.Requests
{
    public class UpdateCartRequestModel
    {
        public UpdateCartRequestModel()
        {
        }

        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

