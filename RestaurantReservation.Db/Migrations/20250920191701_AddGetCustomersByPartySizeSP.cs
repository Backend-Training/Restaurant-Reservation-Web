﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddGetCustomersByPartySizeSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE GetCustomersByPartySize
                @MinPartySize INT
            AS
            BEGIN
                SELECT DISTINCT 
                    c.CustomerId,
                    c.FirstName,
                    c.LastName,
                    c.Email,
                    c.PhoneNumber
                FROM Customers c
                INNER JOIN Reservations r
                    ON c.CustomerId = r.CustomerId
                WHERE r.PartySize > @MinPartySize
            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
