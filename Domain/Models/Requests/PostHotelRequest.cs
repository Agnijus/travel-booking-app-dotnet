﻿
namespace Application.Models.Requests
{
    public class PostHotelRequest
    {
        public int HotelId { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public double? Distance { get; set; }
        public byte? StarRating { get; set; }
        public float? GuestRating { get; set; }
        public ushort? ReviewCount { get; set; }
        public bool? HasFreeCancellation { get; set; }
        public bool? HasPayOnArrival { get; set; }
    }
}
