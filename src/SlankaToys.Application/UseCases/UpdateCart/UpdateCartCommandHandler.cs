using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UpdateCartCommandHandler> _logger;

        public UpdateCartCommandHandler(ICartRepository cartRepository, IProductQueryRepository productQueryRepository,
            ILogger<UpdateCartCommandHandler> logger)
        {
            _cartRepository = cartRepository;
            _productQueryRepository = productQueryRepository;
            _logger = logger;
        }

        public override async Task<UpdateCartCommand> HandleAsync(UpdateCartCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var cart = await _cartRepository.GetCart(command.CartId);
                var product = await _productQueryRepository.FirstOrDefault(a => a.Id == command.ProductId);

                if (cart == null)
                    throw new Exception("Cart not found");

                if (product == null)
                    throw new Exception("Product not found");

                cart.RemoveCartItems(cart.CartItems.Where(i => i.ProductId == command.ProductId));

                cart.AddCartItems(new List<CartItem>() { new CartItem(product.Price, command.Quantity, product.Id) });

                _cartRepository.Update(cart);

                await _cartRepository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("Update cart command failed. ProductId: {productId}, cartId: {CartId}, with exception message: {message}", command.ProductId, command.CartId, ex.Message);
                throw;
            }

            return await base.HandleAsync(command);
        }
    }
}
