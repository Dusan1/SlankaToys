using Paramore.Darker;
using System.Threading;
using System.Threading.Tasks;
using SlankaToys.Application.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SlankaToys.Application.UseCases.GetProducts
{
    public class GetProductsQueryHandler : QueryHandlerAsync<GetProductsQuery, GetProductsQueryResult>
    {
        private readonly IProductQueryRepository _productRepository;
        public GetProductsQueryHandler(IProductQueryRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<GetProductsQueryResult> ExecuteAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _productRepository.Get();
            return new GetProductsQueryResult()
            {
                Products = result.Select(pr => new ProductsModel()
                {
                    Name = pr.Name,
                    Description = pr.Description,
                    ImageFileName = pr.ImageFileName,
                    Price = pr.Price,
                    ProductId = pr.Id
                }).ToList()
            };
        }
    }
}
