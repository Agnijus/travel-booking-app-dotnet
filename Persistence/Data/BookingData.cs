using Domain.Entities;

namespace Persistence.Data
{
    internal class BookingData
    {
        private static int lastId = 0; 

        public static List<Booking> Bookings { get; } = new List<Booking>
        {

        };

        public static int GetNextId()
        {
            return ++lastId; 
        }
    }
}
