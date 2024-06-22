using Domain.Enums;


namespace Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int GuestAccountId { get; set; }
        public int HotelReservationId { get; set; }
        public double TotalPrice { get; set; }
        public int TransactionStatusId { get; set; }

        //Navigation property
        //public TransactionStatus? TransactionStatusId { get; set; }
    }
}

