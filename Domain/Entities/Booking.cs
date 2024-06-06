using Domain.Enums;


namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ReservationId { get; set; }
        public double TotalPrice { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
