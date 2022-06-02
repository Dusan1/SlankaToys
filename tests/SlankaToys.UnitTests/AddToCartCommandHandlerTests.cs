using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SlankaToys.Application.Contracts;
using SlankaToys.Application.UseCases.AddOrder;
using SlankaToys.Domain.Product;

namespace SlankaToys.UnitTests
{
    public class AddToCartCommandHandlerTests
    {
        //private Mock<IProductRepository> productRepository;
        //private Mock<ICartRepository> cartRepository;
        //private AddToCartCommandHandler handler;

        //[SetUp]
        //public void Setup()
        //{
        //    productRepository = new Mock<IProductRepository>();
        //    cartRepository = new Mock<ICartRepository>();
        //    handler = new AddToCartCommandHandler(cartRepository.Object, productRepository.Object);
        //}

        //[Test]
        //public void AddToCartCommandHandler_ThrowsException()
        //{
        //    productRepository
        //        .Setup(repo => repo.FirstOrDefault(It.IsAny<Expression<Func<Product, bool>>>()))
        //        .ThrowsAsync(new Exception());

        //    Assert.ThrowsAsync<Exception>(async () => await handler.HandleAsync(new AddToCartCommand() { }));
        //}
    }
}
