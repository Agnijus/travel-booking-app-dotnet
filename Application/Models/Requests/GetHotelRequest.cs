using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class GetHotelRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Images { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public double? Distance { get; set; }
        public byte? StarRating { get; set; }
        public float? GuestRating { get; set; }
        public int? ReviewCount { get; set; }
        public bool? HasFreeCancellation { get; set; }
        public bool? HasPayOnArrival { get; set; }
    }
}
