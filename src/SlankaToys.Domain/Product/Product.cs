using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlankaToys.Domain.Product
{
    public class Product : IAggregate
    {
        public Product()
        {
        }

        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
  
        public string ImageFileName { get; set; }
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
    }
}
