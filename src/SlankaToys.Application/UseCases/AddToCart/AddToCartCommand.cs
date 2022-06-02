using System;
using Paramore.Brighter;

namespace SlankaToys.Application.UseCases.AddOrder
{
    public class AddToCartCommand : IRequest
    {
        public AddToCartCommand()
        {
            Id = Guid.NewGuid();
        }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
            
        public Guid Id { get; set; }
    }
}
