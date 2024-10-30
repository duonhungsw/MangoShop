using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Service.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CreatedDate", "Description", "Name", "PictureUrl", "Price", "QuantityInStock", "Type" },
                values: new object[,]
                {
                    { new Guid("0eb24374-d544-448d-9cd6-502461a00576"), "GlassTouch", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1269), "A sleek coffee table with a glass top, perfect for modern living spaces.", "Modern Glass Coffee Table", "/images/product-1.png", 200m, 40, "Tables" },
                    { new Guid("12fb7728-dbf9-4345-9465-4235b8c2e612"), "ModernLiving", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1316), "A complete modern dining set with a table and 4 chairs.", "Modern Dining Set", "/images/product-1.png", 800m, 12, "Tables" },
                    { new Guid("1debc4f9-29f3-4a91-bfdd-867238dfca1b"), "CompactLiving", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1310), "A space-saving folding dining table, perfect for small apartments.", "Folding Dining Table", "/images/product-3.png", 220m, 50, "Tables" },
                    { new Guid("1f34ff5c-46a6-4813-b167-8f9d48f8eb26"), "ExecutiveOffice", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1334), "A large, executive-style office desk with ample storage space.", "Executive Office Desk", "/images/product-2.png", 900m, 8, "Tables" },
                    { new Guid("2d316b32-2802-4de1-882f-f679de7e29d0"), "WoodenHeritage", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1324), "A traditional wooden rocking chair, perfect for relaxation.", "Wooden Rocking Chair", "/images/product-2.png", 300m, 15, "Chairs" },
                    { new Guid("3cdbe2e2-6073-474d-ad43-3bbd439a3aa1"), "KidSpace", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1281), "A colorful and sturdy study desk designed for kids.", "Kids Study Desk", "/images/product-1.png", 150m, 35, "Tables" },
                    { new Guid("43a45d5a-068c-43cd-8be6-9d3d0f34fc64"), "DiningEssentials", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1329), "A comfortable fabric dining chair with modern styling.", "Fabric Dining Chair", "/images/product-3.png", 120m, 55, "Chairs" },
                    { new Guid("5a59bae6-09d8-45ce-bdf4-92a34e7d2f95"), "VintageTouch", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1313), "A timeless leather armchair that adds elegance to any room.", "Classic Leather Armchair", "/images/product-3.png", 350m, 18, "Chairs" },
                    { new Guid("5bd642f8-6dcd-4572-a59d-335dc824d217"), "BreatheComfort", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1342), "An ergonomic office chair with a breathable mesh backrest.", "Mesh Back Office Chair", "/images/product-2.png", 160m, 65, "Chairs" },
                    { new Guid("660192c5-e2d9-4bfd-b9d5-2e9a639d6166"), "OutdoorLiving", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1275), "A weather-resistant patio table, great for outdoor dining or lounging.", "Outdoor Patio Table", "/images/product-1.png", 250m, 15, "Tables" },
                    { new Guid("6a0ed200-63f6-472f-88fe-bc7652105310"), "ErgoWork", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1272), "An ergonomic office chair with adjustable height and lumbar support.", "Adjustable Office Chair", "/images/product-2.png", 180m, 60, "Chairs" },
                    { new Guid("8bcfdcd7-3981-4b10-b393-e25fa69d4e6a"), "RelaxMaster", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1278), "A comfortable reclining armchair with plush upholstery.", "Reclining Armchair", "/images/product-2.png", 400m, 20, "Chairs" },
                    { new Guid("a5d058ce-e0be-4af5-8a5f-34b8b740caeb"), "WorkEase", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1318), "A practical swivel chair with wheels, designed for office work.", "Swivel Office Chair", "/images/product-1.png", 140m, 70, "Chairs" },
                    { new Guid("a8a80079-b8f7-4084-a978-60d4910825e1"), "LuxComfort", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1283), "A high-end lounge chair with luxurious fabric and design.", "Luxury Lounge Chair", "/images/product-2.png", 600m, 10, "Chairs" },
                    { new Guid("acc2b221-d436-4799-8300-a6581610f999"), "SpaceSaver", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1326), "A versatile coffee table that converts into a workspace.", "Convertible Coffee Table", "/images/product-3.png", 250m, 22, "Tables" },
                    { new Guid("c639e426-fde8-400a-9142-0fbd7bfc7330"), "BistroStyle", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1321), "A compact outdoor bistro table made of durable materials.", "Outdoor Bistro Table", "/images/product-2.png", 160m, 25, "Tables" },
                    { new Guid("e3adecc8-3f19-401b-b13f-ef222bb72051"), "GlassDining", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1340), "A modern dining table with a tempered glass top.", "Glass Dining Table", "/images/product-1.png", 450m, 30, "Tables" },
                    { new Guid("ef86f701-4c68-4d03-a51d-c5a672616e0b"), "EventSeating", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1337), "A lightweight, stackable plastic chair, ideal for events or gatherings.", "Plastic Stackable Chair", "/images/product-1.png", 50m, 120, "Chairs" },
                    { new Guid("f3b0fe70-6018-441e-96e9-d07683f3088d"), "ClassicHome", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1266), "A sturdy wooden dining table with a classic design, perfect for family meals.", "Classic Wooden Dining Table", "/images/product-3.png", 500m, 25, "Tables" },
                    { new Guid("fa9e0d7e-1ddc-46aa-bfb9-9a1aeef445a0"), "RusticCharm", new DateTime(2024, 10, 22, 11, 12, 25, 60, DateTimeKind.Local).AddTicks(1345), "A vintage-style wooden chair, perfect for rustic-themed rooms.", "Vintage Wooden Chair", "/images/product-3.png", 180m, 40, "Chairs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
