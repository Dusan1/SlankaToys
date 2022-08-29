using Paramore.Darker;
using System.Threading;
using System.Threading.Tasks;
using SlankaToys.Application.Contracts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace SlankaToys.Application.UseCases.GetProducts
{
    public class GetProductsQueryHandler : QueryHandlerAsync<GetProductsQuery, GetProductsQueryResult>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        public GetProductsQueryHandler(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }

        public override async Task<GetProductsQueryResult> ExecuteAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _productQueryRepository.Get();
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
