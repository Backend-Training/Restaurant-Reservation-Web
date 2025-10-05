using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 9, 20, 14, 16, 7, 287, DateTimeKind.Local).AddTicks(5139), 1, 1 },
                    { 2, 2, 4, new DateTime(2025, 9, 21, 14, 16, 7, 289, DateTimeKind.Local).AddTicks(8489), 2, 2 },
                    { 3, 3, 2, new DateTime(2025, 9, 22, 14, 16, 7, 289, DateTimeKind.Local).AddTicks(8513), 3, 3 },
                    { 4, 4, 3, new DateTime(2025, 9, 23, 14, 16, 7, 289, DateTimeKind.Local).AddTicks(8517), 4, 4 },
                    { 5, 5, 6, new DateTime(2025, 9, 24, 14, 16, 7, 289, DateTimeKind.Local).AddTicks(8519), 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);
        }
    }
}
