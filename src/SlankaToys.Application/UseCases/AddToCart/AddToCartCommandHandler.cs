using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Paramore.Brighter;
using SlankaToys.Application.Contracts;
using SlankaToys.Domain.Cart;

namespace SlankaToys.Application.UseCases.AddOrder
{
    public class AddToCartCommandHandler : RequestHandlerAsync<AddToCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public AddToCartCommandHandler(
            ICartRepository cartRepository,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public override async Task<AddToCartCommand> HandleAsync(AddToCartCommand command, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetProductById(command.ProductId);

            if (product is null)
            {
                throw new Exception("Product not found!");
            }

            Cart cart;

            cart = await _cartRepository.GetUserCartWithItems(command.UserId);

            if (cart == null)
            {
                cart = new Cart(DateTime.UtcNow, command.UserId);
                cart.AddCartItems(new CartItem()
                {
                    ItemPrice = product.Price,
                    Quantity = command.ProductQuantity,
                    ProductId = product.Id
                });
            }
            else
            {
                if (!cart.CartItems.Any(ci => ci.ProductId == product.Id))
                {
                    cart.AddCartItems(new CartItem()
                    {
                        ItemPrice = product.Price,
                        Quantity = command.ProductQuantity,
                        ProductId = product.Id
                    });
                }
                else
                {
                    var currentCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == product.Id);

                    if (currentCartItem == null)
                    {
                        throw new Exception("");
                    }

                    currentCartItem.Quantity++;
                }
            }
  

            if (cart.Id > 0)
            {
                _cartRepository.Update(cart);
            }
            else
            {
                _cartRepository.Add(cart);
            }

            try
            {
               
                await _cartRepository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                var f = ex;
            }

            return await base.HandleAsync(command);
        }
    }
}
