
namespace Domain.Entities
{
    public class GuestAccount
    {
        public int GuestAccountId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
