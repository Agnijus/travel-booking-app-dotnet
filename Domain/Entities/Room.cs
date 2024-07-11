
namespace Domain.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; } 
        public ushort PricePerNight { get; set; }

        // Navigation property
        // public RoomTypes RoomType { get; set; } 


        // No longer needed because I'm not instantiating the Room when creating a Hotel

        //public Room(int roomId, int hotelId, int roomTypeId, ushort pricePerNight)
        //{
        //    RoomId = roomId;
        //    HotelId = hotelId;
        //    RoomTypeId = roomTypeId;
        //    PricePerNight = pricePerNight;
        //}
    }
}
