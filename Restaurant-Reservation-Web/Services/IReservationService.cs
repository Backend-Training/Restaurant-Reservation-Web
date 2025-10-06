using Restaurant_Reservation_Web.DTOs;
using RestaurantReservation.Db.Models;

namespace Restaurant_Reservation_Web.Services;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task<Reservation?> GetOneAsync(int id);
    Task<Reservation> CreateAsync(ReservationDto reservation);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(int id, ReservationDto reservation);
}