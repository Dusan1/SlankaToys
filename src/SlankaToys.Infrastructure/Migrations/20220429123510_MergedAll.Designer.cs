﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlankaToys.Infrastructure;

#nullable disable

namespace SlankaToys.Infrastructure.Migrations
{
    [DbContext(typeof(SlankaToysDbContext))]
    [Migration("20220429123510_MergedAll")]
    partial class MergedAll
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SlankaToys.Domain.Cart.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CartId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("SlankaToys.Domain.Cart.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("SlankaToys.Domain.Order.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("SlankaToys.Domain.Order.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderItemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("SlankaToys.Domain.Product.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageFileName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Toys for children up to 3 years of age.",
                            Name = "0-3"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Toys for children from 3 to 6 years of age.",
                            Name = "3-6"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Toys for children from 6 to 9 years of age.",
                            Name = "6-9"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Toys for children made out of fleece.",
                            Name = "Fleece toys"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lego toys for children.",
                            Name = "Lego toys"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Educational toys for children.",
                            Name = "Educational toys"
                        });
                });

            modelBuilder.Entity("SlankaToys.Domain.Product.CategoryProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryProductId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("CategoryProduct", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 6,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            ProductId = 4
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            ProductId = 5
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 6,
                            ProductId = 5
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            ProductId = 6
                        });
                });

            modelBuilder.Entity("SlankaToys.Domain.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageFileName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Plastic lion to ride",
                            ImageFileName = "ride_lion.jpg",
                            Name = "Ride lion",
                            Price = 5m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Barbie toy",
                            ImageFileName = "barbie.jpg",
                            Name = "Barbie",
                            Price = 8.5m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Puzzle of Minnie Mouse. It has 250 pieces",
                            ImageFileName = "minnie_puzzle.jpg",
                            Name = "Minnie Puzzle",
                            Price = 12.4m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Lego doll house for girls.",
                            ImageFileName = "lego_doll_house.jpg",
                            Name = "Lego doll house",
                            Price = 14.9m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Puzzle of frozen cartoon.It has 100 pieces",
                            ImageFileName = "frozen_puzzle.jpg",
                            Name = "Frozen Puzzle",
                            Price = 5m,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Fleece bear toy.",
                            ImageFileName = "fleece_bear.jpg",
                            Name = "Fleece bear",
                            Price = 5m,
                            ProductTypeId = 1
                        });
                });

            modelBuilder.Entity("SlankaToys.Domain.Product.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductTypeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageFileName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProductType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Children toys.",
                            Name = "Toys"
                        });
                });

            modelBuilder.Entity("SlankaToys.Domain.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Forename")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("State")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "marin.dusan2@gmail.com",
                            Password = "Test1234;"
                        },
                        new
                        {
                            Id = 2,
                            Email = "marin.dusan3@gmail.com",
                            Password = "Test1234;"
                        });
                });

            modelBuilder.Entity("SlankaToys.Domain.Cart.Cart", b =>
                {
                    b.HasOne("SlankaToys.Domain.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SlankaToys.Domain.Cart.CartItem", b =>
                {
                    b.HasOne("SlankaToys.Domain.Cart.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlankaToys.Domain.Product.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SlankaToys.Domain.Order.Order", b =>
                {
                    b.HasOne("SlankaToys.Domain.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SlankaToys.Domain.Order.OrderItem", b =>
                {
                    b.HasOne("SlankaToys.Domain.Order.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlankaToys.Domain.Product.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SlankaToys.Domain.Product.CategoryProduct", b =>
                {
                    b.HasOne("SlankaToys.Domain.Product.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlankaToys.Domain.Product.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SlankaToys.Domain.Product.Product", b =>
                {
                    b.HasOne("SlankaToys.Domain.Product.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("SlankaToys.Domain.Cart.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("SlankaToys.Domain.Order.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("SlankaToys.Domain.Product.Product", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
