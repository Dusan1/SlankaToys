using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paramore.Brighter;

namespace SlankaToys.Application.UseCases.UpdateCart
{
    public class UpdateCartCommand : IRequest
    {
        public UpdateCartCommand()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
