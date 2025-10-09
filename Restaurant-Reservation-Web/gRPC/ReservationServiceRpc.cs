using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Restaurant_Reservation_Web.Services;

namespace Restaurant_Reservation_Web.gRPC;

public class ReservationServiceRpc : ReservationRpc.ReservationRpcBase
{
    private IReservationService _reservationService;

    public ReservationServiceRpc(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public override async Task<ReservationResponse> GetReservationById(ReservationRequest request, ServerCallContext context)
    {
        var reservation = await _reservationService.GetOneAsync(request.Id);
        var response = new ReservationResponse
        {
            ReservationId = reservation.ReservationId,
            CustomerId = reservation.CustomerId,
            CustomerName = reservation.CustomerName,
            RestaurantId = reservation.RestaurantId,
            RestaurantName = reservation.RestaurantName,
            TableId = (int) reservation.TableId,
            ReservationDate = Timestamp.FromDateTime(reservation.ReservationDate.ToUniversalTime()),
            PartySize = reservation.PartySize
        };
        return response;
    }
}