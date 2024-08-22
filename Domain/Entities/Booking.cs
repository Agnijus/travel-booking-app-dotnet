
namespace Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int GuestAccountId { get; set; }
        public int HotelReservationId { get; set; }
        public int TotalPrice { get; set; }
        public int TransactionStatusId { get; set; }

        public GuestAccount? GuestAccount { get; set; }
        public HotelReservation? HotelReservation { get; set; }
        public TransactionStatus? TransactionStatus { get; set; }
    }
}

