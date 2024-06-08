using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Entities;

namespace Persistence.Data
{
    internal class PopularDestinationData
    {
        public static List<string> PopularDestinations {get; } = new List<string>()
        {
           "Las Vegas", "London","Miami","Los Angeles","Chicago",
           "New York","Tokyo","Cancum","Orlando","Paris"
        };
    }
}
