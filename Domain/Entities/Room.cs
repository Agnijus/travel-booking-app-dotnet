

namespace Domain.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; } 
        public ushort PricePerNight { get; set; }

    }
}
