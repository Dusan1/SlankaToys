using System;
namespace SlankaToys.Domain.Product
{
    public class CategoryProduct :IEntity
    {
        public CategoryProduct()
        {
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
