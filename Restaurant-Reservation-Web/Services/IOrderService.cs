using Restaurant_Reservation_Web.DTOs;

namespace Restaurant_Reservation_Web.Services;

public interface IOrderService
{
    Task<List<OrderSummaryDto>> ListOrdersByReservations(int id);
}