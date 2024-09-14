using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CQRSArchitecture.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("56dbf0c2-27f0-4e3c-a435-1aa4ccf8cf5f"), "Sony's top-of-the-line wireless noise-canceling headphones", "Sony WH-1000XM4", 349.99m },
                    { new Guid("9d5efcd2-20a2-4240-bfc4-fca69c128ae6"), "Apple's latest flagship smartphone with a ProMotion display and improved cameras", "iPhone 15 Pro", 999.99m },
                    { new Guid("b8ced01b-d020-425e-91db-8b5ed99cb3a3"), "Dell's high-performance laptop with a 4K InfinityEdge display", "Dell XPS 15", 1899.99m }
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
