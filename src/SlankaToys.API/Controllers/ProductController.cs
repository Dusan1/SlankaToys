using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using SlankaToys.API.Responses;
using SlankaToys.Application.UseCases.GetProduct;
using SlankaToys.Application.UseCases.GetProducts;

namespace SlankaToys.API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;
        
        public ProductController(IQueryProcessor queryProcessor) 
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("products")]
        public async Task<IEnumerable<ProductsResponse>> Get()
        {
            var result = await _queryProcessor.ExecuteAsync(new GetProductsQuery() { SearchTerm = "" });
            return result.Products.Select(pr => new ProductsResponse()
            {
                Name = pr.Name,
                Description = pr.Description,
                ImageFileName = pr.ImageFileName,
                Price = pr.Price,
                ProductId = pr.ProductId
            });
        }

        [HttpGet]
        [Route("product")]
        public async Task<ProductsResponse> Get(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetProductQuery() { ProductId = id });
            return new ProductsResponse()
            {
                Name = result.Name,
                Description = result.Description,
                ImageFileName = result.ImageFileName,
                Price = result.Price,
                ProductId = result.ProductId
            };
        }
    }
    
   
}
