using System;
using System.Collections.Generic;

namespace SlankaToys.Application.UseCases.GetProducts
{
    public class GetProductsQueryResult
    {
        public GetProductsQueryResult()
        {
        }

        public List<ProductsModel> Products { get; set; }
    }
}
