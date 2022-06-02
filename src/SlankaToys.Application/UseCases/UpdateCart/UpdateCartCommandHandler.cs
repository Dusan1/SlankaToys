using Paramore.Brighter;
using SlankaToys.Application.Contracts;
using SlankaToys.Domain.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlankaToys.Application.UseCases.UpdateCart
{
    public  class UpdateCartCommandHandler : RequestHandlerAsync<UpdateCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        public UpdateCartCommandHandler(ICartRepository cartRepository, IProductQueryRepository productQueryRepository)
        {
            _cartRepository = cartRepository;
            _productQueryRepository = productQueryRepository;
        }

        public override async Task<UpdateCartCommand> HandleAsync(UpdateCartCommand command, CancellationToken cancellationToken = default)
        {
            var cart = await _cartRepository.GetCart(command.CartId);
            var product = await _productQueryRepository.FirstOrDefault(a => a.Id == command.ProductId);

            cart.RemoveCartItems(cart.CartItems.Where(i => i.ProductId == command.ProductId));

            cart.AddCartItems(new CartItem() 
            {
                ItemPrice = product.Price,
                Quantity = command.Quantity,
                ProductId = product.Id
            });

            _cartRepository.Update(cart);

            await _cartRepository.SaveChangesAsync();

            return await base.HandleAsync(command);
        }
    }
}
