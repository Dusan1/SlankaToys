using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SlankaToys.Application.Contracts;
using SlankaToys.Application.UseCases.GetProducts;
using SlankaToys.Domain;
using SlankaToys.Domain.Product;

namespace SlankaToys.UnitTests
{
    public class GetProductsQueryHandlerTests
    {
        //private Mock<IProductRepository> productRepository;
        //private GetProductsQueryHandler getProductsQueryHandler;

        //[SetUp]
        //public void Setup()
        //{
        //    productRepository = new Mock<IProductRepository>();
        //    getProductsQueryHandler = new GetProductsQueryHandler(productRepository.Object);
        //}

        //[Test]
        //public async Task GetProductsQueryHandler_ReturnsCorrectResult()
        //{
        //    productRepository.Setup(repo => repo.Get()).ReturnsAsync(new List<Product>()
        //    {
        //        new Product()
        //        {
        //            Description = "test1",
        //            ImageFileName = "test1",
        //            Name = "test1",
        //            Price = 1M,
        //            Id = 1
        //        }
        //    });

        //    var queryResult = await getProductsQueryHandler.ExecuteAsync(new GetProductsQuery() { SearchTerm = "" });

        //    Assert.AreEqual(1, queryResult.Products.Count);
        //    Assert.AreEqual("test1", queryResult.Products.SingleOrDefault().Description);
        //    Assert.AreEqual("test1", queryResult.Products.SingleOrDefault().ImageFileName);
        //    Assert.AreEqual("test1", queryResult.Products.SingleOrDefault().Name);
        //    Assert.AreEqual(1M, queryResult.Products.SingleOrDefault().Price);
        //    Assert.AreEqual(1, queryResult.Products.SingleOrDefault().ProductId);
        //    productRepository.Verify(pr => pr.Get(), Times.Once);
        //}
    }
}