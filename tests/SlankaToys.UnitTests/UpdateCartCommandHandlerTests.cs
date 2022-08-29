using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SlankaToys.Application.Contracts;
using SlankaToys.Application.UseCases.UpdateCart;
using SlankaToys.Domain.Cart;
using SlankaToys.Domain.Product;
using SlankaToys.Infrastructure.Repository;
using SlankaToys.UnitTests.Builders;

namespace SlankaToys.UnitTests
{
    public class UpdateCartCommandHandlerTests
    {
        private Mock<IProductQueryRepository> productQueryRepository;
        private Mock<ICartRepository> cartRepository;
        private UpdateCartCommandHandler handler;
        private UpdateCartCommandHandler handlerNoMock;
        private Mock<ILogger<UpdateCartCommandHandler>> _logger;
        private TestDataBuilder testDataBuilder;

        [SetUp]
        public void Setup()
        {
            productQueryRepository = new Mock<IProductQueryRepository>();
            _logger = new Mock<ILogger<UpdateCartCommandHandler>>();
            cartRepository = new Mock<ICartRepository>();
            handler = new UpdateCartCommandHandler(cartRepository.Object, productQueryRepository.Object, _logger.Object);

            //In-memory setup
            var contextFactory = new TestContextFactory();
            testDataBuilder = new TestDataBuilder(contextFactory);

            handlerNoMock = new UpdateCartCommandHandler(new CartRepository(contextFactory.SlankaToysDbContext),
                new ProductQueryRepository(contextFactory.SlankaToysDbContext), null);
        }

        [Test]
        public void UpdateCartCommandHandler_WhenInvoked_ThrowsException()
        {
            productQueryRepository
                .Setup(repo => repo.FirstOrDefault(It.IsAny<Expression<Func<Product, bool>>>()))
                .ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await handler.HandleAsync(new UpdateCartCommand() { }));
        }

        [Test]
        public async Task UpdateCartCommandHandler_WhenInvoked_SaveChangesCalled()
        {
            productQueryRepository
                .Setup(repo => repo.FirstOrDefault(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(new Product("test", "test", "test", 3.5m, 1)
                {
                    Id  = 12
                });

            var cart = new Cart(DateTime.UtcNow, 1, Domain.Enums.CartStatus.Pending)
            {
                Id = 3
            };

            cart.AddCartItems(new List<CartItem>() { new CartItem(2.8m, 3, 12) });

            cartRepository.Setup(cr => cr.GetCart(It.IsAny<int>()))
            .ReturnsAsync(cart);

            await handler.HandleAsync(new UpdateCartCommand() { Id = Guid.NewGuid(), CartId = 3, ProductId = 12, Quantity = 5 });

            cartRepository.Verify(pr => pr.Update(It.IsAny<Cart>()), Times.Once);
            cartRepository.Verify(pr => pr.SaveChangesAsync(), Times.Once);
        }

        
        [Test]
        public async Task UpdateCartCommandHandler_WhenInvoked_CartIsUpdatedCorrectly()
        {
            var product = new ProductBuilder("test", "testDesc", "test", 2.5m, 1).Build();

            await testDataBuilder.WithProduct(product);

            var cart = new CartBuilder(DateTime.UtcNow, 1)
                .WithStatus(Domain.Enums.CartStatus.Pending)
                .WithCartItems(new List<CartItem>() { new CartItem(2.5m, 1, product.Id) })
                .Build();

            await testDataBuilder.WithCart(cart);

            await handlerNoMock.HandleAsync(new UpdateCartCommand()
            {
                ProductId = product.Id,
                Quantity = 5,
                CartId = cart.Id
            });

            var updatedCart = await testDataBuilder.CartRepository.GetCart(cart.Id);

            Assert.IsNotNull(updatedCart.CartItems.First());
            Assert.AreEqual(5, updatedCart.CartItems.First().Quantity);
        }

        

    }
}
