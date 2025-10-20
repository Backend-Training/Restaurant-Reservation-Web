using Restaurant_Reservation_Web.DTOs;

namespace Restaurant_Reservation_Web.Services;

public interface IMenuItemsService
{
    Task<List<MenuItemsReadDto>> ListOrderedMenuItemsByReservation(int id);
}