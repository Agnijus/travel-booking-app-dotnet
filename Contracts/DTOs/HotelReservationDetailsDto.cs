using Domain.Enums;


namespace Contracts.DTOs
{
    public class HotelReservationDetailsDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public RoomType RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalPrice { get; set; }
    }
}

