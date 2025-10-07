using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Web.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace Restaurant_Reservation_Web.Services;

public class OrderService : IOrderService
{
    private IRepository<Order> _orderRepository;

    public OrderService(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderSummaryDto>> ListOrdersByReservations(int id)
    {
        return await _orderRepository.Entities()
            .Where(o => o.ReservationId == id)
            .Select(o => new OrderSummaryDto()
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount
            }).ToListAsync();
    }
}