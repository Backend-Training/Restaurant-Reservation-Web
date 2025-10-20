using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Restaurant_Reservation_Web.Services;

namespace Restaurant_Reservation_Web.Endpoints;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this WebApplication app)
    {
        app.MapGet("/reservations/{id:int}/orders", async (int id, IOrderService orderService) =>
        {
            var orders = await orderService.ListOrdersByReservations(id);
            return Results.Ok(orders);
        });
    }
}