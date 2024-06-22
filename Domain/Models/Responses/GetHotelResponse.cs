
using Domain.Entities;

namespace Application.Models.Responses
{
    public class GetHotelResponse
    {
        public int HotelId { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public double? Distance { get; set; }
        public byte? StarRating { get; set; }
        public float? GuestRating { get; set; }
        public int? ReviewCount { get; set; }
        public bool? HasFreeCancellation { get; set; }
        public bool? HasPayOnArrival { get; set; }


        // Join and get Images and Rooms associated with the HotelId
        // IEnumerable because I won't be modifying, only iterating

        public ICollection<string>? Images  { get; set; }
        public ICollection<Room>? Rooms { get; set; }

    }
}
