using Domain.Enums;

namespace Domain.Entities
{
    public class HotelReservationDetails
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public RoomType RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalPrice { get; set; }
    }
}
