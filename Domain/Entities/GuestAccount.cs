
namespace Domain.Entities
{
    public class GuestAccount
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
