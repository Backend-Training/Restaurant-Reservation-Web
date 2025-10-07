using Restaurant_Reservation_Web.DTOs;

namespace Restaurant_Reservation_Web.Services;

public interface ICustomerService
{
    Task<ReservationReadDto> ListReservationByCustomer(int id);
}