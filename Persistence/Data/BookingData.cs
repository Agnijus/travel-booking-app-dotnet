using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
