using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using travel_booking_app_dotnet.Core.Entities;

namespace Persistence.Data
{
    internal class HotelData
    {
        public static List<Hotel> Hotels { get; } = new List<Hotel>
        {
            new Hotel
            {
              Id = 1,
              Name = "Conrad Las Vegas at Resorts World",
              Images = new string[]
              {
                 "/Assets/image1_0.jpeg",
                 "/Assets/image1_1.jpeg",
                 "/Assets/image1_2.jpeg"
              },
              Address =
                "111 Resorts World Avenue, Downtown Las Vegas, Las Vegas, 89109, United States",
              Distance = 0.8,
              StarRating = 5,
              GuestRating = 3.0f,
              ReviewCount = 731,
              PricePerNight = 173,
              HasFreeCancellation = true,
              HasPayOnArrival = false,
            },
            new Hotel
            {
              Id = 2,
              Name = "Waldorf Astoria Las Vegas",
              Images = new string[]
              {
                "/Assets/image2_0.jpeg",
                "/Assets/image2_1.jpeg",
                "/Assets/image2_2.jpeg"
              },
              Address =
                "3752 Las Vegas Boulevard South, Downtown Las Vegas, Las Vegas, 89158, United States",
              Distance = 0.72,
              StarRating = 5,
              GuestRating = 4.0f,
              ReviewCount = 1092,
              PricePerNight = 287,
              HasFreeCancellation = false,
              HasPayOnArrival = false,
            },
            new Hotel
            {
              Id = 3,
              Name = "The Orleans Hotel & Casino",
              Images = new string[]
              {
                "/Assets/image3_0.jpeg",
                "/Assets/image3_1.jpeg",
                "/Assets/image3_2.jpeg"
              },
              Address =
                "4500 W Tropicana Ave, Southwest Valley, Las Vegas, 89103, United States",
              Distance = 1.71,
              StarRating = 3,
              GuestRating = 3.7f,
              ReviewCount = 6816,
              PricePerNight = 83,
              HasFreeCancellation = false,
              HasPayOnArrival = true,
            }
        };   
    }
}
