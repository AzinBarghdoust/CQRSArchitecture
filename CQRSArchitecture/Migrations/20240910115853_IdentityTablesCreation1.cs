using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CQRSArchitecture.Migrations
{
    /// <inheritdoc />
    public partial class IdentityTablesCreation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a81493a-11bf-44d1-8d60-bc2076e1ea90"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e423bb2-e7ef-4ec2-95d1-52ffc8880862"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c77943be-9cb4-4451-ab99-747ae3957a8e"));

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "DeliveredDate", "Description", "Name", "OrderedDate", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5c6a7e5f-cdb5-408c-a825-5bb0f2e2de9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Apple's latest flagship smartphone with a ProMotion display and improved cameras", "iPhone 15 Pro", null, 999.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("67f53fd5-d1c0-4a65-a476-f1e661cdf020"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dell's high-performance laptop with a 4K InfinityEdge display", "Dell XPS 15", null, 1899.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f994cff7-97eb-4da1-bbc0-c30d4d855bd5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sony's top-of-the-line wireless noise-canceling headphones", "Sony WH-1000XM4", null, 349.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5c6a7e5f-cdb5-408c-a825-5bb0f2e2de9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67f53fd5-d1c0-4a65-a476-f1e661cdf020"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f994cff7-97eb-4da1-bbc0-c30d4d855bd5"));

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "OrderDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "DeliveredDate", "Description", "Name", "OrderedDate", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6a81493a-11bf-44d1-8d60-bc2076e1ea90"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Apple's latest flagship smartphone with a ProMotion display and improved cameras", "iPhone 15 Pro", null, 999.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e423bb2-e7ef-4ec2-95d1-52ffc8880862"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dell's high-performance laptop with a 4K InfinityEdge display", "Dell XPS 15", null, 1899.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c77943be-9cb4-4451-ab99-747ae3957a8e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sony's top-of-the-line wireless noise-canceling headphones", "Sony WH-1000XM4", null, 349.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
