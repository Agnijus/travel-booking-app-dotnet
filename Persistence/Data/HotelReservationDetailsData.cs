using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
