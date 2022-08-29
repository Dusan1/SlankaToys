using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Paramore.Darker;
using SlankaToys.Application.Contracts;

namespace SlankaToys.Application.UseCases.GetCart
{
    public class GetCartQueryHandler : QueryHandlerAsync<GetCartQuery, GetCartQueryResult>
    {
        private readonly ICartQueryRepository _cartQueryRepository;
        public GetCartQueryHandler(ICartQueryRepository cartRepository)
        {
            _cartQueryRepository = cartRepository;
        }

        public override async Task<GetCartQueryResult> ExecuteAsync(GetCartQuery query, CancellationToken cancellationToken = default)
        {
            
            var cart = await _cartQueryRepository.GetUserCartWithItems(query.UserId);

            if (cart == null)
                return new GetCartQueryResult() { Items = new List<CartItemResult>() };

            return new GetCartQueryResult()
            {
                Date = cart.Date,
                CartId = cart.Id,
                Items = cart.CartItems.GroupBy(ci => ci.ProductId).Select(ci => new CartItemResult()
               { 
                    ProductName = ci.FirstOrDefault()?.Product?.Name,
                    Price = ci.FirstOrDefault()?.Product?.Price ?? 0m,
                    Quantity = ci.Sum(q => q.Quantity),
                    ImageFileName = ci.FirstOrDefault()?.Product?.ImageFileName,
                    ProductId = ci.FirstOrDefault()?.Product.Id ?? 0
                }).ToList()
            };

        }
    }
}
