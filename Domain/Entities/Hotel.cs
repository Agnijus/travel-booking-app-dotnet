namespace travel_booking_app_dotnet.Core.Entities
{
    internal class Hotel
    {
        public uint Id { get; set;  }
        public string Name { get; set; }
        public string[] Images { get; set; }
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
