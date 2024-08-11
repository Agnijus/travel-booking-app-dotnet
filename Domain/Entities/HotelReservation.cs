

namespace Domain.Entities
{
    public class HotelReservation
    {
        public int HotelReservationId { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalPrice { get; set; }


    }
}
