using Domain.Enums;

namespace Application.Models.Requests;

public class PostBookingRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? ContactNumber { get; set; }
    public int HotelId { get; set; }
    public RoomType RoomType { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public double TotalPrice { get; set; }
}
