using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Web.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace Restaurant_Reservation_Web.Services;

public class MenuItemsService : IMenuItemsService
{
    private IRepository<Order> _orderRepostiory;

    public MenuItemsService(IRepository<Order> orderRepostiory)
    {
        _orderRepostiory = orderRepostiory;
    }

    public async Task<List<MenuItemsReadDto>> ListOrderedMenuItemsByReservation(int id)
    {
        return await _orderRepostiory.Entities().Where(o => o.ReservationId == id)
            .SelectMany(o => o.OrderItems)
            .Select(oi => new MenuItemsReadDto()
            {
                Id = oi.MenuItem.Id,
                RestaurantId = oi.MenuItem.RestaurantId,
                Name = oi.MenuItem.Name,
                Description = oi.MenuItem.Description,
                Price = oi.MenuItem.Price
            }).ToListAsync();
    }
}