using Domain.Entities;



namespace Persistence.Data
{
    internal class HotelReservationDetailsData
    {
        private static int lastId = 0;

        public static List<HotelReservationDetails> HotelReservations { get; } = new List<HotelReservationDetails>
        {
           
        };

        public static int GetNextId()
        {
            return ++lastId;
        }
    }
}
