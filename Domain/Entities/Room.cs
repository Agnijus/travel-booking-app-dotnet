using Domain.Enums;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; } 
        public RoomTypes RoomType { get; set; } 
        public ushort PricePerNight { get; set; }

    
        public Room(int id, int roomTypeId, ushort pricePerNight)
        {
            Id = id;
            RoomTypeId = roomTypeId;
            RoomType = (RoomTypes)roomTypeId; 
            PricePerNight = pricePerNight;
        }
    }
}
