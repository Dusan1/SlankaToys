using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlankaToys.Domain.Product;

namespace SlankaToys.Infrastructure.Mappings
{
    public class CategoryProductMap : IEntityTypeConfiguration<CategoryProduct>
    {
        public CategoryProductMap() 
        {
        }

        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.ToTable("CategoryProduct").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("CategoryProductId");

            builder.HasData(new List<CategoryProduct>()
            {
                new CategoryProduct(){ Id = 1,ProductId=1, CategoryId = 1 },
                new CategoryProduct(){ Id = 2,ProductId=2, CategoryId = 2 },
                new CategoryProduct(){ Id = 3,ProductId=3, CategoryId = 3 },
                new CategoryProduct(){ Id = 4,ProductId=3, CategoryId = 6 },
                new CategoryProduct(){ Id = 5,ProductId=4, CategoryId = 5 },
                new CategoryProduct(){ Id = 6,ProductId=5, CategoryId = 2 },
                new CategoryProduct(){ Id = 7,ProductId=5, CategoryId = 6 },
                new CategoryProduct(){ Id = 8,ProductId=6, CategoryId = 4 },
            });

        }
    }
}
