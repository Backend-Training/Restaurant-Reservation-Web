using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Web.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace Restaurant_Reservation_Web.Services;

public class EmployeeService : IEmployeeService
{
    private IRepository<Employee> _employeeRepoistory;
    private IRepository<Order> _orderRepository;

    public EmployeeService(IRepository<Employee> employeeRepoistory, IRepository<Order> orderRepository)
    {
        _employeeRepoistory = employeeRepoistory;
        _orderRepository = orderRepository;
    }

    public async Task<List<EmployeeReadDto>> ListAllManagers()
    {
        return await _employeeRepoistory.Entities()
            .Where(e => e.Position == "Manager")
            .Select(e => new EmployeeReadDto()
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Orders = e.Orders.Select(o => new OrderSummaryDto()
                {
                    OrderDate = o.OrderDate,
                    OrderId = o.OrderId,
                    TotalAmount = o.TotalAmount
                }).ToList(),
                Position = e.Position,
                RestaurantAddress = e.Restaurant.Address,
                RestaurantId = e.RestaurantId,
                RestaurantName = e.Restaurant.Name
            }).ToListAsync();
    }

    public async Task<decimal> CalculateAverageOrderAmount(int employeeId)
    {
        return await _orderRepository.Entities()
            .Where(o => o.EmployeeId == employeeId)
            .AverageAsync(o => o.TotalAmount);
    }
}