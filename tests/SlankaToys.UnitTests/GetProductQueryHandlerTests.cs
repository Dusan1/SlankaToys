using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SlankaToys.Application.Contracts;
using SlankaToys.Application.UseCases.GetProduct;
using SlankaToys.Domain;
using SlankaToys.Domain.Product;

namespace SlankaToys.UnitTests
{
    public class GetProductQueryHandlerTests
    {
        private GetProductQueryHandler getProductQueryHandler;
        private Mock<IProductQueryRepository> productQueryRepository;
       

        [SetUp]
        public void Setup()
        {
            productQueryRepository = new Mock<IProductQueryRepository>();
            getProductQueryHandler = new GetProductQueryHandler(productQueryRepository.Object);
        }

        [Test]
        public async Task GetProductQueryHandler_WhenInvoked_ReturnsCorrectResult()
        {
            productQueryRepository.Setup(repo => repo.FirstOrDefault(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(
                new Product("test2", "test2", "test2", 2m, 1)
            {
                Id = 2
            });

            var queryResult = await getProductQueryHandler.ExecuteAsync(new GetProductQuery() { ProductId = 1 });

            Assert.IsNotNull(queryResult);
            Assert.AreEqual("test2", queryResult.Description);
            Assert.AreEqual("test2", queryResult.ImageFileName);
            Assert.AreEqual("test2", queryResult.Name);
            Assert.AreEqual(2M, queryResult.Price);
            Assert.AreEqual(2, queryResult.ProductId);
            productQueryRepository.Verify(pr => pr.FirstOrDefault(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        }
    }
}
