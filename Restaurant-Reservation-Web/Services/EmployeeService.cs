using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Web.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace Restaurant_Reservation_Web.Services;

public class EmployeeService : IEmployeeService
{
    private IRepository<Employee> _employeeRepoistory;

    public EmployeeService(IRepository<Employee> employeeRepoistory)
    {
        _employeeRepoistory = employeeRepoistory;
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

    public Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        throw new NotImplementedException();
    }
}