using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlankaToys.Domain.Cart;
using SlankaToys.Domain.Enums;

namespace SlankaToys.Infrastructure.Mappings
{
    public class CartMap : IEntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
        }

        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("CartId");

            
        }
    }
}
