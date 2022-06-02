using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlankaToys.Domain.User;

namespace SlankaToys.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public UserMap()
        {
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("UserId");

            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Forename).HasMaxLength(50);
            builder.Property(p => p.Surname).HasMaxLength(50);
            builder.Property(p => p.Address).HasMaxLength(100);
            builder.Property(p => p.City).HasMaxLength(50);
            builder.Property(p => p.PostalCode).HasMaxLength(50);
            builder.Property(p => p.State).HasMaxLength(100);

            builder.HasData(new List<User>()
            {
                new User() { Id = 1, Email = "marin.dusan2@gmail.com", Password = "Test1234;" },
                new User() { Id = 2, Email = "marin.dusan3@gmail.com", Password = "Test1234;" }
            });
        }
    }
}
