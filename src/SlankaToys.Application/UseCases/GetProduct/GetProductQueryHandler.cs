using System.Threading;
using System.Threading.Tasks;
using Paramore.Darker;
using SlankaToys.Application.Contracts;

namespace SlankaToys.Application.UseCases.GetProduct
{
    public class GetProductQueryHandler : QueryHandlerAsync<GetProductQuery, GetProductQueryResult>
    {
        private readonly IProductQueryRepository _productRepository;
        public GetProductQueryHandler(IProductQueryRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<GetProductQueryResult> ExecuteAsync(GetProductQuery query, CancellationToken cancellationToken = default)
        {
            var pr = await _productRepository.FirstOrDefault(a=> a.Id == query.ProductId);
            return new GetProductQueryResult()
            {

                ProductId = pr.Id,
                Name = pr.Name,
                    Description = pr.Description,
                    ImageFileName = pr.ImageFileName,
                    Price = pr.Price
                
            };
        }
    }
}
