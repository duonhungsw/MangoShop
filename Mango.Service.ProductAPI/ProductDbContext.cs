using Mango.Service.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.ProductAPI;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Classic Wooden Dining Table",
     Description = "A sturdy wooden dining table with a classic design, perfect for family meals.",
     Price = 500,
     PictureUrl = "/images/product-3.png",
     Type = "Tables",
     Brand = "ClassicHome",
     QuantityInStock = 25,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Modern Glass Coffee Table",
     Description = "A sleek coffee table with a glass top, perfect for modern living spaces.",
     Price = 200,
     PictureUrl = "/images/product-1.png",
     Type = "Tables",
     Brand = "GlassTouch",
     QuantityInStock = 40,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Adjustable Office Chair",
     Description = "An ergonomic office chair with adjustable height and lumbar support.",
     Price = 180,
     PictureUrl = "/images/product-2.png",
     Type = "Chairs",
     Brand = "ErgoWork",
     QuantityInStock = 60,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Outdoor Patio Table",
     Description = "A weather-resistant patio table, great for outdoor dining or lounging.",
     Price = 250,
     PictureUrl = "/images/product-1.png",
     Type = "Tables",
     Brand = "OutdoorLiving",
     QuantityInStock = 15,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Reclining Armchair",
     Description = "A comfortable reclining armchair with plush upholstery.",
     Price = 400,
     PictureUrl = "/images/product-2.png",
     Type = "Chairs",
     Brand = "RelaxMaster",
     QuantityInStock = 20,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Kids Study Desk",
     Description = "A colorful and sturdy study desk designed for kids.",
     Price = 150,
     PictureUrl = "/images/product-1.png",
     Type = "Tables",
     Brand = "KidSpace",
     QuantityInStock = 35,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Luxury Lounge Chair",
     Description = "A high-end lounge chair with luxurious fabric and design.",
     Price = 600,
     PictureUrl = "/images/product-2.png",
     Type = "Chairs",
     Brand = "LuxComfort",
     QuantityInStock = 10,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Folding Dining Table",
     Description = "A space-saving folding dining table, perfect for small apartments.",
     Price = 220,
     PictureUrl = "/images/product-3.png",
     Type = "Tables",
     Brand = "CompactLiving",
     QuantityInStock = 50,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Classic Leather Armchair",
     Description = "A timeless leather armchair that adds elegance to any room.",
     Price = 350,
     PictureUrl = "/images/product-3.png",
     Type = "Chairs",
     Brand = "VintageTouch",
     QuantityInStock = 18,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Modern Dining Set",
     Description = "A complete modern dining set with a table and 4 chairs.",
     Price = 800,
     PictureUrl = "/images/product-1.png",
     Type = "Tables",
     Brand = "ModernLiving",
     QuantityInStock = 12,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Swivel Office Chair",
     Description = "A practical swivel chair with wheels, designed for office work.",
     Price = 140,
     PictureUrl = "/images/product-1.png",
     Type = "Chairs",
     Brand = "WorkEase",
     QuantityInStock = 70,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Outdoor Bistro Table",
     Description = "A compact outdoor bistro table made of durable materials.",
     Price = 160,
     PictureUrl = "/images/product-2.png",
     Type = "Tables",
     Brand = "BistroStyle",
     QuantityInStock = 25,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Wooden Rocking Chair",
     Description = "A traditional wooden rocking chair, perfect for relaxation.",
     Price = 300,
     PictureUrl = "/images/product-2.png",
     Type = "Chairs",
     Brand = "WoodenHeritage",
     QuantityInStock = 15,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Convertible Coffee Table",
     Description = "A versatile coffee table that converts into a workspace.",
     Price = 250,
     PictureUrl = "/images/product-3.png",
     Type = "Tables",
     Brand = "SpaceSaver",
     QuantityInStock = 22,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Fabric Dining Chair",
     Description = "A comfortable fabric dining chair with modern styling.",
     Price = 120,
     PictureUrl = "/images/product-3.png",
     Type = "Chairs",
     Brand = "DiningEssentials",
     QuantityInStock = 55,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Executive Office Desk",
     Description = "A large, executive-style office desk with ample storage space.",
     Price = 900,
     PictureUrl = "/images/product-2.png",
     Type = "Tables",
     Brand = "ExecutiveOffice",
     QuantityInStock = 8,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Plastic Stackable Chair",
     Description = "A lightweight, stackable plastic chair, ideal for events or gatherings.",
     Price = 50,
     PictureUrl = "/images/product-1.png",
     Type = "Chairs",
     Brand = "EventSeating",
     QuantityInStock = 120,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Glass Dining Table",
     Description = "A modern dining table with a tempered glass top.",
     Price = 450,
     PictureUrl = "/images/product-1.png",
     Type = "Tables",
     Brand = "GlassDining",
     QuantityInStock = 30,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Mesh Back Office Chair",
     Description = "An ergonomic office chair with a breathable mesh backrest.",
     Price = 160,
     PictureUrl = "/images/product-2.png",
     Type = "Chairs",
     Brand = "BreatheComfort",
     QuantityInStock = 65,
     CreatedDate = DateTime.Now,
 },
 new Product
 {
     Id = Guid.NewGuid(),
     Name = "Vintage Wooden Chair",
     Description = "A vintage-style wooden chair, perfect for rustic-themed rooms.",
     Price = 180,
     PictureUrl = "/images/product-3.png",
     Type = "Chairs",
     Brand = "RusticCharm",
     QuantityInStock = 40,
     CreatedDate = DateTime.Now,
 }
);

    }
}
