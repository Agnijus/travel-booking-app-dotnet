

namespace Domain.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; } 
        public ushort PricePerNight { get; set; }

        public Hotel? Hotel { get; set; }
        public RoomType? RoomType { get; set; }


    }
}
