
namespace Domain.Entities
{
    public class TransactionStatus
    {
        public int TransactionStatusId { get; set; }
        public string? Description { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
