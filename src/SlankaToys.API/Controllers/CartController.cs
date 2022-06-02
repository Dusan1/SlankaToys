using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using Paramore.Darker;
using SlankaToys.API.Requests;
using SlankaToys.Application.UseCases.AddOrder;
using SlankaToys.Application.UseCases.GetCart;
using SlankaToys.Application.UseCases.UpdateCart;

namespace SlankaToys.API.Controllers
{
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly IAmACommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;

        public CartController(IAmACommandProcessor commandProcessor, IQueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        [HttpPost]
        [Route("cart")]
        public async Task<ActionResult> AddToCart(AddToCartRequestModel request)
        {
            await _commandProcessor.SendAsync(new AddToCartCommand()
            {
                ProductId = request.ProductId,
                ProductQuantity = request.Quantity,
                UserId = request.UserId
            });
            return Ok("success");
        }

        [HttpGet]
        [Route("cart/{userId}")]
        public async Task<GetCartQueryResult> GetCart(int userId)
        {
            return await _queryProcessor.ExecuteAsync(new GetCartQuery()
            {
                UserId = userId
            });
        }

        [HttpPut]
        [Route("cart")]
        public async Task<ActionResult> UpdateCart(UpdateCartRequestModel request)
        {
            await _commandProcessor.SendAsync(new UpdateCartCommand()
            {
                ProductId = request.ProductId,
                CartId = request.CartId,
                Quantity = request.Quantity
            });
            return Ok("success");
        }
    }
}
