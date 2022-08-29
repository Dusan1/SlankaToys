using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlankaToys.Domain.Product
{
    public class Product : IAggregate
    {
        public Product(string name, string description, string imageFileName, decimal price, int productTypeId)
        {
            Name = name;
            Description = description;
            ImageFileName = imageFileName;
            Price = price;
            ProductTypeId = productTypeId;
        }

        public int Id { get; set; }
       
        public string Name { get; private set; }
        public string Description { get; private set; }
  
        public string ImageFileName { get; private set; }
        public decimal Price { get; private set; }
        public int ProductTypeId { get; private set; }

        public ProductType ProductType { get; set; }
    }
}
