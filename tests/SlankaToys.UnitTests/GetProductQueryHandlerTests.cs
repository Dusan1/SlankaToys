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
        //private Mock<IProductRepository> productRepository;
        //private GetProductQueryHandler getProductQueryHandler;

        //[SetUp]
        //public void Setup()
        //{
        //    productRepository = new Mock<IProductRepository>();
        //    getProductQueryHandler = new GetProductQueryHandler(productRepository.Object);
        //}

        //[Test]
        //public async Task GetProductQueryHandler_ReturnsCorrectResult()
        //{
        //    productRepository.Setup(repo => repo.FirstOrDefault(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(new Product()
        //    {
        //        Description = "test2",
        //        ImageFileName = "test2",
        //        Name = "test2",
        //        Price = 2M,
        //        Id = 2
        //    });

        //    var queryResult = await getProductQueryHandler.ExecuteAsync(new GetProductQuery() { ProductId = 1 });

        //    Assert.IsNotNull(queryResult);
        //    Assert.AreEqual("test2", queryResult.Description);
        //    Assert.AreEqual("test2", queryResult.ImageFileName);
        //    Assert.AreEqual("test2", queryResult.Name);
        //    Assert.AreEqual(2M, queryResult.Price);
        //    Assert.AreEqual(2, queryResult.ProductId);
        //    productRepository.Verify(pr => pr.FirstOrDefault(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        //}
    }
}
