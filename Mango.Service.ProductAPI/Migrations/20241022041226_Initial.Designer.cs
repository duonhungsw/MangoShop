﻿// <auto-generated />
using System;
using Mango.Service.ProductAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mango.Service.ProductAPI.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20241022041226_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mango.Service.ProductAPI.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f3b0fe70-6018-441e-96e9-d07683f3088d"),
                            Brand = "ClassicHome",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1266),
                            Description = "A sturdy wooden dining table with a classic design, perfect for family meals.",
                            Name = "Classic Wooden Dining Table",
                            PictureUrl = "/images/product-3.png",
                            Price = 500m,
                            QuantityInStock = 25,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("0eb24374-d544-448d-9cd6-502461a00576"),
                            Brand = "GlassTouch",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1269),
                            Description = "A sleek coffee table with a glass top, perfect for modern living spaces.",
                            Name = "Modern Glass Coffee Table",
                            PictureUrl = "/images/product-1.png",
                            Price = 200m,
                            QuantityInStock = 40,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("6a0ed200-63f6-472f-88fe-bc7652105310"),
                            Brand = "ErgoWork",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1272),
                            Description = "An ergonomic office chair with adjustable height and lumbar support.",
                            Name = "Adjustable Office Chair",
                            PictureUrl = "/images/product-2.png",
                            Price = 180m,
                            QuantityInStock = 60,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("660192c5-e2d9-4bfd-b9d5-2e9a639d6166"),
                            Brand = "OutdoorLiving",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1275),
                            Description = "A weather-resistant patio table, great for outdoor dining or lounging.",
                            Name = "Outdoor Patio Table",
                            PictureUrl = "/images/product-1.png",
                            Price = 250m,
                            QuantityInStock = 15,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("8bcfdcd7-3981-4b10-b393-e25fa69d4e6a"),
                            Brand = "RelaxMaster",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1278),
                            Description = "A comfortable reclining armchair with plush upholstery.",
                            Name = "Reclining Armchair",
                            PictureUrl = "/images/product-2.png",
                            Price = 400m,
                            QuantityInStock = 20,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("3cdbe2e2-6073-474d-ad43-3bbd439a3aa1"),
                            Brand = "KidSpace",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1281),
                            Description = "A colorful and sturdy study desk designed for kids.",
                            Name = "Kids Study Desk",
                            PictureUrl = "/images/product-1.png",
                            Price = 150m,
                            QuantityInStock = 35,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("a8a80079-b8f7-4084-a978-60d4910825e1"),
                            Brand = "LuxComfort",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1283),
                            Description = "A high-end lounge chair with luxurious fabric and design.",
                            Name = "Luxury Lounge Chair",
                            PictureUrl = "/images/product-2.png",
                            Price = 600m,
                            QuantityInStock = 10,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("1debc4f9-29f3-4a91-bfdd-867238dfca1b"),
                            Brand = "CompactLiving",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1310),
                            Description = "A space-saving folding dining table, perfect for small apartments.",
                            Name = "Folding Dining Table",
                            PictureUrl = "/images/product-3.png",
                            Price = 220m,
                            QuantityInStock = 50,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("5a59bae6-09d8-45ce-bdf4-92a34e7d2f95"),
                            Brand = "VintageTouch",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1313),
                            Description = "A timeless leather armchair that adds elegance to any room.",
                            Name = "Classic Leather Armchair",
                            PictureUrl = "/images/product-3.png",
                            Price = 350m,
                            QuantityInStock = 18,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("12fb7728-dbf9-4345-9465-4235b8c2e612"),
                            Brand = "ModernLiving",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1316),
                            Description = "A complete modern dining set with a table and 4 chairs.",
                            Name = "Modern Dining Set",
                            PictureUrl = "/images/product-1.png",
                            Price = 800m,
                            QuantityInStock = 12,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("a5d058ce-e0be-4af5-8a5f-34b8b740caeb"),
                            Brand = "WorkEase",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1318),
                            Description = "A practical swivel chair with wheels, designed for office work.",
                            Name = "Swivel Office Chair",
                            PictureUrl = "/images/product-1.png",
                            Price = 140m,
                            QuantityInStock = 70,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("c639e426-fde8-400a-9142-0fbd7bfc7330"),
                            Brand = "BistroStyle",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1321),
                            Description = "A compact outdoor bistro table made of durable materials.",
                            Name = "Outdoor Bistro Table",
                            PictureUrl = "/images/product-2.png",
                            Price = 160m,
                            QuantityInStock = 25,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("2d316b32-2802-4de1-882f-f679de7e29d0"),
                            Brand = "WoodenHeritage",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1324),
                            Description = "A traditional wooden rocking chair, perfect for relaxation.",
                            Name = "Wooden Rocking Chair",
                            PictureUrl = "/images/product-2.png",
                            Price = 300m,
                            QuantityInStock = 15,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("acc2b221-d436-4799-8300-a6581610f999"),
                            Brand = "SpaceSaver",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1326),
                            Description = "A versatile coffee table that converts into a workspace.",
                            Name = "Convertible Coffee Table",
                            PictureUrl = "/images/product-3.png",
                            Price = 250m,
                            QuantityInStock = 22,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("43a45d5a-068c-43cd-8be6-9d3d0f34fc64"),
                            Brand = "DiningEssentials",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1329),
                            Description = "A comfortable fabric dining chair with modern styling.",
                            Name = "Fabric Dining Chair",
                            PictureUrl = "/images/product-3.png",
                            Price = 120m,
                            QuantityInStock = 55,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("1f34ff5c-46a6-4813-b167-8f9d48f8eb26"),
                            Brand = "ExecutiveOffice",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1334),
                            Description = "A large, executive-style office desk with ample storage space.",
                            Name = "Executive Office Desk",
                            PictureUrl = "/images/product-2.png",
                            Price = 900m,
                            QuantityInStock = 8,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("ef86f701-4c68-4d03-a51d-c5a672616e0b"),
                            Brand = "EventSeating",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1337),
                            Description = "A lightweight, stackable plastic chair, ideal for events or gatherings.",
                            Name = "Plastic Stackable Chair",
                            PictureUrl = "/images/product-1.png",
                            Price = 50m,
                            QuantityInStock = 120,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("e3adecc8-3f19-401b-b13f-ef222bb72051"),
                            Brand = "GlassDining",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1340),
                            Description = "A modern dining table with a tempered glass top.",
                            Name = "Glass Dining Table",
                            PictureUrl = "/images/product-1.png",
                            Price = 450m,
                            QuantityInStock = 30,
                            Type = "Tables"
                        },
                        new
                        {
                            Id = new Guid("5bd642f8-6dcd-4572-a59d-335dc824d217"),
                            Brand = "BreatheComfort",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1342),
                            Description = "An ergonomic office chair with a breathable mesh backrest.",
                            Name = "Mesh Back Office Chair",
                            PictureUrl = "/images/product-2.png",
                            Price = 160m,
                            QuantityInStock = 65,
                            Type = "Chairs"
                        },
                        new
                        {
                            Id = new Guid("fa9e0d7e-1ddc-46aa-bfb9-9a1aeef445a0"),
                            Brand = "RusticCharm",
                            CreatedDate = new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1345),
                            Description = "A vintage-style wooden chair, perfect for rustic-themed rooms.",
                            Name = "Vintage Wooden Chair",
                            PictureUrl = "/images/product-3.png",
                            Price = 180m,
                            QuantityInStock = 40,
                            Type = "Chairs"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
