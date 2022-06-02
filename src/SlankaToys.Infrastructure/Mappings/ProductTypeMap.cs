using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlankaToys.Domain.Product;

namespace SlankaToys.Infrastructure.Mappings
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public ProductTypeMap()
        {
        }

        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("ProductTypeId");

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.ImageFileName).HasMaxLength(100);
            
            builder.HasData(new ProductType() { Id = 1, Name = "Toys", Description = "Children toys." });
        }
    }
}
