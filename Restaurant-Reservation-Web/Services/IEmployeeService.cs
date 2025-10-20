using Restaurant_Reservation_Web.DTOs;

namespace Restaurant_Reservation_Web.Services;

public interface IEmployeeService
{
    Task<List<EmployeeReadDto>> ListAllManagers();
    Task<decimal> CalculateAverageOrderAmount(int employeeId);
}