

namespace Domain.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public double? Distance { get; set; } 
        public int? StarRating { get; set; } 
        public double? GuestRating { get; set; } 
        public int? ReviewCount { get; set; } 
        public bool? HasFreeCancellation { get; set; } 
        public bool? HasPayOnArrival { get; set; }

        public ICollection<HotelImage>? HotelImages { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}

