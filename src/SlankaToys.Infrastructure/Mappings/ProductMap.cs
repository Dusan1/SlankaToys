using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlankaToys.Domain.Product;

namespace SlankaToys.Infrastructure.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("ProductId");

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.ImageFileName).HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(new List<Product>()
            {
                new Product("Ride lion", "Plastic lion to ride", "ride_lion.jpg", 5m, 1) { Id = 1 },
                new Product("Barbie", "Barbie toy", "barbie.jpg", 8.5m, 1) { Id = 2 },
                new Product("Minnie Puzzle", "Puzzle of Minnie Mouse. It has 250 pieces", "minnie_puzzle.jpg", 12.4m, 1) { Id = 3 },
                new Product("Lego doll house", "Lego doll house for girls.", "lego_doll_house.jpg", 14.9m, 1) { Id = 4 },
                new Product("Frozen Puzzle", "Puzzle of frozen cartoon.It has 100 pieces", "frozen_puzzle.jpg", 5m, 1) { Id = 5 },
                new Product("Fleece bear", "Fleece bear toy.",  "fleece_bear.jpg", 5m, 1) { Id = 6 }
            });
        }
    }
}
