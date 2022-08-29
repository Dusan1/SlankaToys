using System;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SlankaToys.Application.Contracts;
using SlankaToys.Application.UseCases.AddOrder;

namespace SlankaToys.UnitTests
{
    public class AddToCartCommandHandlerTests
    {
        private Mock<IProductRepository> productRepository;
        private Mock<ICartRepository> cartRepository;
        private AddToCartCommandHandler handler;
        private Mock<ILogger<AddToCartCommandHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            productRepository = new Mock<IProductRepository>();
            cartRepository = new Mock<ICartRepository>();
            _logger = new Mock<ILogger<AddToCartCommandHandler>>();
            handler = new AddToCartCommandHandler(cartRepository.Object, productRepository.Object, _logger.Object);
        }

        [Test]
        public void AddToCartCommandHandler_ThrowsException()
        {
            productRepository
                .Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await handler.HandleAsync(new AddToCartCommand() { }));
        }
    }
}
