using System;
using System.Collections.Generic;

namespace SlankaToys.Application.UseCases.GetCart
{
    public class GetCartQueryResult
    {
        public GetCartQueryResult()
        {
        }
        public DateTime Date { get; set; }
        public int CartId { get; set; }

        public List<CartItemResult> Items { get; set; }
    }
}
