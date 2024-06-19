
namespace Domain.Entities
{
    public class PostBookingRequest
    {
        public GuestAccount? GuestAccount { get; set; }
        public HotelReservationDetails? HotelReservationDetails { get; set; }
    }
}
