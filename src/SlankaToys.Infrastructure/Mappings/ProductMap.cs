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
                new Product(){ Id = 1,ProductTypeId = 1, Name = "Ride lion", Description = "Plastic lion to ride", Price = 5M, ImageFileName = "ride_lion.jpg" },//0-3
                new Product(){ Id = 2,ProductTypeId = 1, Name = "Barbie", Description = "Barbie toy", Price = 8.5M, ImageFileName = "barbie.jpg" },//3-6
                new Product(){ Id = 3,ProductTypeId = 1, Name = "Minnie Puzzle", Description = "Puzzle of Minnie Mouse. It has 250 pieces", Price = 12.4M, ImageFileName = "minnie_puzzle.jpg" },//6-9, edu
                new Product(){ Id = 4,ProductTypeId = 1, Name = "Lego doll house", Description = "Lego doll house for girls.", Price = 14.9M, ImageFileName = "lego_doll_house.jpg" },//lego
                new Product(){ Id = 5,ProductTypeId = 1, Name = "Frozen Puzzle", Description = "Puzzle of frozen cartoon.It has 100 pieces", Price = 5M, ImageFileName = "frozen_puzzle.jpg" },//3-6, edu
                new Product(){ Id = 6,ProductTypeId = 1, Name = "Fleece bear", Description = "Fleece bear toy.", Price = 5M, ImageFileName = "fleece_bear.jpg" }//fleece
            });
        }
    }
}
