using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlankaToys.Domain.Cart;

namespace SlankaToys.Infrastructure.Mappings
{
    public class CartItemMap : IEntityTypeConfiguration<CartItem>
    {
        public CartItemMap()
        {
        }

        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("CartItemId");
        }
    }
}
