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
        public static List<PopularDestination> PopularDestinations {get; } = new List<PopularDestination>()
        {
            new PopularDestination
            {
                Name = "Las Vegas",
                Location = "Clark County, Nevada, United States"
            },
            new PopularDestination
            {
                Name = "London",
                Location = "England, United Kingdom"
            },
            new PopularDestination
            {
                Name = "Miami",
                Location = "Miami-Dade, Florida, United States"
            },
            new PopularDestination
            {
                Name = "Los Angeles",
                Location = "California, United States"
            },
            new PopularDestination
            {
                Name = "Chicago",
                Location = "Cook County, Illinois, United States"
            },
            new PopularDestination
            {
                Name = "New York",
                Location = "United States"
            },
            new PopularDestination
            {
                Name = "Tokyo",
                Location = "Japan"
            },
            new PopularDestination
            {
                Name = "Cancum",
                Location = "Quintana Roo, Mexico"
            },
            new PopularDestination
            {
                Name = "Orlando",
                Location = "Orange County, Florida, United States"
            },
            new PopularDestination
            {
                Name = "Paris",
                Location = "Île-de-France, France"
            },
        };
    }
}
