using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SlankaToys.Domain.User;
using SlankaToys.Domain.Product;
using SlankaToys.Domain.Cart;

namespace SlankaToys.Infrastructure
{
    public class SlankaToysDbContext : DbContext
    {
        //public SlankaToysDbContext()
        //{
        //}



        public SlankaToysDbContext(DbContextOptions<SlankaToysDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost; Database=SlankaToysDb;User=SA; Password=mypaSS123:");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
