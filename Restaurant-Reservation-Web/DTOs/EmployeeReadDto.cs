namespace Restaurant_Reservation_Web.DTOs;

public class EmployeeReadDto
{
    public int EmployeeId { get; set; }
    public int RestaurantId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public List<OrderSummaryDto> Orders { get; set; }
}