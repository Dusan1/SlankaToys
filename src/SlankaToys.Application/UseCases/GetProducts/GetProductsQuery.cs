using Paramore.Darker;
namespace SlankaToys.Application.UseCases.GetProducts
{
    public class GetProductsQuery : IQuery<GetProductsQueryResult>
    {
        public GetProductsQuery()
        {
        }

        public string SearchTerm { get; set; }
    }
}
