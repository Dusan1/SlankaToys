using System;
using Paramore.Darker;

namespace SlankaToys.Application.UseCases.GetCart
{
    public class GetCartQuery : IQuery<GetCartQueryResult>
    {
        public GetCartQuery()
        {
        }

        public int UserId { get; set; }

    }
}
