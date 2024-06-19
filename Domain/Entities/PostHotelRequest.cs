using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostHotelRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Images { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public string Address { get; set; }
        public string City { get; set; }
        public double Distance { get; set; }
        public byte StarRating { get; set; }
        public float GuestRating { get; set; }
        public ushort ReviewCount { get; set; }
        public bool HasFreeCancellation { get; set; }
        public bool HasPayOnArrival { get; set; }
    }
}
