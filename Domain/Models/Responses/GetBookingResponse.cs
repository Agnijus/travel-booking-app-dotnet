

namespace Domain.Models.Responses
{
    public class GetBookingResponse
    {
        public int BookingId { get; set; }
        public string? FullName { get; set; }
        public string? HotelTitle { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalPrice { get; set; }
        public string? TransactionStatus { get; set; }
    }
}
