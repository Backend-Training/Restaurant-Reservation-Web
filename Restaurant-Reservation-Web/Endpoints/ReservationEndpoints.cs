using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Restaurant_Reservation_Web.DTOs;
using Restaurant_Reservation_Web.Services;

namespace Restaurant_Reservation_Web.Endpoints;

public static class ReservationEndpoints
{
    public static void MapReservationsEndPoints(this WebApplication app)
    {
        app.MapGet("/reservations/", async (IReservationService reservationService) =>
        {
            var reservations = await reservationService.GetAllAsync();
            return Results.Ok(reservations.ToList());
        });
        app.MapGet("/reservations/{id:int}", async (int id, IReservationService reservationService) =>
        {
            var reservation = await reservationService.GetOneAsync(id);
            return reservation is not null ? Results.Ok(reservation) : Results.NotFound();
        });
        app.MapPost("/reservations", async (ReservationDto reservationDto, IReservationService reservationService) =>
        {
            var reservatrion = await reservationService.CreateAsync(reservationDto);
            return Results.Ok(reservatrion);
        }).RequireAuthorization();
        app.MapDelete("/reservations/{id:int}", async (int id, IReservationService reservationService) =>
        {
            var result = await reservationService.DeleteAsync(id);
            return result == true ? Results.Ok(result) : Results.NotFound();
        }).RequireAuthorization();
        app.MapPut("/reservations/{id:int}",
            async (int id, ReservationDto reservationDto, IReservationService reservationService) =>
            {
                var result = await reservationService.UpdateAsync(id, reservationDto);
                return result == true ? Results.Ok(result) : Results.NotFound();
            }).RequireAuthorization();
    }
}