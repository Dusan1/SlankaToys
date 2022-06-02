using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using SlankaToys.Application.UseCases.AddOrder;

namespace SlankaToys.API.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IAmACommandProcessor _commandProcessor;
        public OrderController(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpPost]
        [Route("order")]
        public async Task<string> AddOrder(int userId, int productId, int quantity)
        {
            //await _commandProcessor.SendAsync(new AddToCartCommand()
            //{
            //    ProductId = productId,
            //    ProductQuantity = quantity,
            //    UserId = userId
            //});
            return await Task.FromResult(string.Empty);
        }
    }
}
