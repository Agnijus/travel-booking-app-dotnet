using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Images { get; set; }
        public List<RoomDto> Rooms { get; set; } = new List<RoomDto>();

        public string Address { get; set; }
        public double Distance { get; set; }
        public byte StarRating { get; set; }
        public float GuestRating { get; set; }
        public ushort ReviewCount { get; set; }
        public ushort PricePerNight { get; set; }
        public bool hasFreeCancellation { get; set; }
        public bool hasPayOnArrival { get; set; }
    
    }
}
