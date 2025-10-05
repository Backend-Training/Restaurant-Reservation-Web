using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationRestaurantCustomerView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW vw_ReservationDetails AS
                SELECT 
                    r.ReservationId,
                    r.ReservationDate,
                    r.PartySize,
                    c.CustomerId,
                    c.FirstName AS CustomerName,
                    c.Email AS CustomerEmail,
                    rest.RestaurantId,
                    rest.Name AS RestaurantName,
                    rest.Address AS RestaurantAddress
                FROM Reservations r
                INNER JOIN Customers c ON r.CustomerId = c.CustomerId
                INNER JOIN Restaurants rest ON r.RestaurantId = rest.RestaurantId;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
