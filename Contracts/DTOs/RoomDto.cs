using Domain.Enums;


namespace Contracts.DTOs
{
    public class RoomDto
    {

        public int Id { get; set; }

        public RoomType RoomType { get; set; }
        public ushort PricePerNight { get; set; }

       

    }
}
