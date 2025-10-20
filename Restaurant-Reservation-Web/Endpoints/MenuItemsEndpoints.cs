using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Restaurant_Reservation_Web.Services;

namespace Restaurant_Reservation_Web.Endpoints;

public static class MenuItemsEndpoints
{
    public static void MapMenuItemsEndpoints(this WebApplication app)
    {
        app.MapGet("/reservations/{id:int}/menu-items", async (int id, IMenuItemsService menuItemsService) =>
        {
            var orderedMenuItems = await menuItemsService.ListOrderedMenuItemsByReservation(id);
            return Results.Ok(orderedMenuItems);
        });
    }
}