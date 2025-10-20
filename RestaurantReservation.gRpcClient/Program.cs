using Grpc.Net.Client;


using var channel =
    GrpcChannel.ForAddress("http://localhost:5001");
var client = new ReservationRpc.ReservationRpcClient(channel);

var request = new ReservationRequest { Id = 3 };
var response = await client.GetReservationByIdAsync(request);

Console.WriteLine($"Reservation for: {response.CustomerName}");