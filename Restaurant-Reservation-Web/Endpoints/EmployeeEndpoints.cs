using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Restaurant_Reservation_Web.Services;

namespace Restaurant_Reservation_Web.Endpoints;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this WebApplication app)
    {
        app.MapGet("/employees/managers", async (IEmployeeService employeeService) =>
        {
            var managers = await employeeService.ListAllManagers();
            return Results.Ok(managers);
        });

        app.MapGet("/employees/{id:int}/average-order-amount", async (int id, IEmployeeService employeeService) =>
        {
            var average = await employeeService.CalculateAverageOrderAmount(id);
            return Results.Ok(average);
        });
    }
}