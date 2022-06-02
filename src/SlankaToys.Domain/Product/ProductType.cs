using System;
using System.ComponentModel.DataAnnotations;

namespace SlankaToys.Domain.Product
{
    public class ProductType : IEntity //??? maybe only value object
    {
        public ProductType()
        {
        }


        public int Id { get; set; }
     
        public string Name { get; set; }
        public string Description { get; set; }
 
        public string ImageFileName { get; set; }
    }
}
