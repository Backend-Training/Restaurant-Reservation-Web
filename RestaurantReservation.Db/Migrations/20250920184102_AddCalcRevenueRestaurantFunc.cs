using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddCalcRevenueRestaurantFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION CalculateRestaurantRevenue(@RestaurantId INT)
                RETURNS DECIMAL(10,2)
                AS
                BEGIN
                    DECLARE @Revenue DECIMAL(10,2);

                    SELECT @Revenue = SUM(o.TotalAmount)
                    FROM Orders o
                    INNER JOIN Reservations r ON o.ReservationId = r.ReservationId
                    WHERE r.RestaurantId = @RestaurantId;

                    RETURN ISNULL(@Revenue, 0);
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
