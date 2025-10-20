using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 20m },
                    { 2, 2, new DateTime(2025, 9, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 35m },
                    { 3, 3, new DateTime(2025, 9, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 25m },
                    { 4, 4, new DateTime(2025, 9, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, 15m },
                    { 5, 5, new DateTime(2025, 9, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, 50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);
        }
    }
}
