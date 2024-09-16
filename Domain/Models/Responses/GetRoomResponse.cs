

namespace Domain.Models.Responses
{
    public class GetRoomResponse
    {
        public int RoomTypeId { get; set; }
        public string? Description { get; set; }
        public ushort PricePerNight { get; set; }
    }
}
