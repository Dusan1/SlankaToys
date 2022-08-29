using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.WebPubSub;
using Microsoft.Extensions.Logging;
using Paramore.Brighter;
using SlankaToys.Application.Contracts;
using SlankaToys.Domain.Cart;
using SlankaToys.Domain.Product;

namespace SlankaToys.Application.UseCases.AddOrder
{
    public class AddToCartCommandHandler : RequestHandlerAsync<AddToCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<AddToCartCommandHandler> _logger;

        public AddToCartCommandHandler(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            ILogger<AddToCartCommandHandler> logger)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _logger = logger;
        }

        public override async Task<AddToCartCommand> HandleAsync(AddToCartCommand command, CancellationToken cancellationToken = default)
        {
            try
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
                    cart.AddCartItems(new List<CartItem>()
                    {
                        new CartItem(product.Price, command.ProductQuantity, product.Id)
                    });
                }
                else
                {
                    if (!cart.CartItems.Any(ci => ci.ProductId == product.Id))
                    {
                        cart.AddCartItems(new List<CartItem>()
                        {
                            new CartItem(product.Price, command.ProductQuantity, product.Id)
                        });
                    }
                    else
                    {
                        var currentCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == product.Id);

                        if (currentCartItem == null)
                        {
                            throw new Exception("Cart item not found");
                        }

                        currentCartItem.SetQuantity(command.ProductQuantity);
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

                await _cartRepository.SaveChangesAsync();

                //var serviceClient = new WebPubSubServiceClient("Endpoint=https://slankatoys.webpubsub.azure.com;AccessKey=Z+ooFHTrH64ELSs6L/Pf6aF1Qh1HNZe/lZrKyB7tcFc=;Version=1.0;", "slankatoys");
                //await serviceClient.SendToAllAsync("test332");
            }
            catch(Exception ex)
            {
                _logger.LogError("Add cart command failed. ProductId: {productId}, userId: {UserId}, with exception message: {message}", command.ProductId, command.UserId, ex.Message);
                throw;
            }

            return await base.HandleAsync(command);
        }
    }
}
