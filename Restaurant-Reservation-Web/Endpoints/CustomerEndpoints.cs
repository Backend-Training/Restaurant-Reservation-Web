using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Restaurant_Reservation_Web.Services;

namespace Restaurant_Reservation_Web.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapGet("/reservations/customer/{id:int}", async (int id, ICustomerService customerService) =>
        {
            var reservations = await customerService.ListReservationByCustomer(id);
            return Results.Ok(reservations);
        });
    }
}