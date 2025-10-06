using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Web.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace Restaurant_Reservation_Web.Services;

public class ReservationService : IReservationService
{
    private IRepository<Reservation> _reservationRepository;

    public ReservationService(IRepository<Reservation> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await Task.FromResult
            (_reservationRepository.Entities().AsEnumerable());
    }

    public async Task<Reservation?> GetOneAsync(int id)
    {
        return await _reservationRepository
            .Entities()
            .FirstOrDefaultAsync(r => r.ReservationId == id);
    }

    public async Task<Reservation> CreateAsync(ReservationDto reservationDto)
    {
        var reservation = new Reservation()
        {
            CustomerId = reservationDto.CustomerId,
            RestaurantId = reservationDto.RestaurantId,
            TableId = reservationDto.TableId,
            ReservationDate = reservationDto.ReservationDate,
            PartySize = reservationDto.PartySize
        };
        _reservationRepository.Create(reservation);

        return await Task.FromResult(reservation);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (await GetOneAsync(id) == null) return false;
        _reservationRepository.Delete(id);

        return true;
    }

    public async Task<bool> UpdateAsync(int id, ReservationDto reservationDto)
    {
        if (await GetOneAsync(id) == null) return false;
        var reservation = new Reservation()
        {
            ReservationId = id,
            CustomerId = reservationDto.CustomerId,
            RestaurantId = reservationDto.RestaurantId,
            TableId = reservationDto.TableId,
            ReservationDate = reservationDto.ReservationDate,
            PartySize = reservationDto.PartySize
        };
        _reservationRepository.Update(reservation);
        return true;
    }
}