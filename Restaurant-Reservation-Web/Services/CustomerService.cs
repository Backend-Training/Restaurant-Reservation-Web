using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Web.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace Restaurant_Reservation_Web.Services;

public class CustomerService : ICustomerService
{
    private IRepository<Reservation> _reservationRepository;

    public CustomerService(IRepository<Reservation> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<List<ReservationReadDto>> ListReservationByCustomer(int id)
    {
        return await _reservationRepository.Entities().Where(r => r.CustomerId == id)
            .Select(r => new ReservationReadDto()
            {
                CustomerId = r.CustomerId,
                CustomerName = r.Customer.FirstName + " " + r.Customer.LastName,
                PartySize = r.PartySize,
                ReservationDate = r.ReservationDate,
                ReservationId = r.ReservationId,
                RestaurantId = r.RestaurantId,
                RestaurantName = r.Restaurant.Name,
                TableId = r.TableId
            }).ToListAsync();
    }
}
