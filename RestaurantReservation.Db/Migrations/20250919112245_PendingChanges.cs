using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class PendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 20, 14, 22, 44, 402, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 21, 14, 22, 44, 405, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 22, 14, 22, 44, 405, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 23, 14, 22, 44, 405, DateTimeKind.Local).AddTicks(659));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 24, 14, 22, 44, 405, DateTimeKind.Local).AddTicks(662));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 20, 14, 16, 7, 287, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 21, 14, 16, 7, 289, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 22, 14, 16, 7, 289, DateTimeKind.Local).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 23, 14, 16, 7, 289, DateTimeKind.Local).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2025, 9, 24, 14, 16, 7, 289, DateTimeKind.Local).AddTicks(8519));
        }
    }
}
