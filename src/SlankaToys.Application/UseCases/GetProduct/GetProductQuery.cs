using System;
using Paramore.Darker;
namespace SlankaToys.Application.UseCases.GetProduct
{
    public class GetProductQuery : IQuery<GetProductQueryResult>
    {
        public GetProductQuery()
        {
        }

        public int ProductId { get; set; }
    }
}
