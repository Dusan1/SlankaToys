using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlankaToys.Domain.Product;

namespace SlankaToys.Infrastructure.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("CategoryId");

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.ImageFileName).HasMaxLength(100);

            builder.HasData(new List<Category>()
            {
                new Category() { Id = 1, Name = "0-3", Description = "Toys for children up to 3 years of age." },
                new Category() { Id = 2, Name = "3-6", Description = "Toys for children from 3 to 6 years of age." },
                new Category() { Id = 3, Name = "6-9", Description = "Toys for children from 6 to 9 years of age." },
                new Category() { Id = 4, Name = "Fleece toys", Description = "Toys for children made out of fleece." },
                new Category() { Id = 5, Name = "Lego toys", Description = "Lego toys for children." },
                new Category() { Id = 6, Name = "Educational toys", Description = "Educational toys for children." }
            });
        }
    }
}
