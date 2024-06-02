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
                "https://content.skyscnr.com/available/1215563226/1215563226_320x252.jpg",
                "https://content.skyscnr.com/available/1303344146/1303344146_WxH.jpg",
                "https://content.skyscnr.com/available/1215563226/1215563226_320x252.jpg",
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
                "https://content.skyscnr.com/available/1394098245/1394098245_320x252.jpg",
                "https://content.skyscnr.com/available/1303344146/1303344146_WxH.jpg",
                "https://content.skyscnr.com/available/1215563226/1215563226_320x252.jpg",
              },
              Address =
                "111 Resorts World Avenue, Downtown Las Vegas, Las Vegas, 89109, United States",
              Distance = 0.72,
              StarRating = 5,
              GuestRating = 4.0f,
              ReviewCount = 1086,
              PricePerNight = 304,
              HasFreeCancellation = false,
              HasPayOnArrival = false,
            },
            new Hotel
            {
              Id = 3,
              Name = "The Orleans Hotel & Casino",
              Images = new string[]
              {
                "https://content.skyscnr.com/available/1167715507/1167715507_640x504.jpg",
                "https://content.skyscnr.com/available/1303344146/1303344146_WxH.jpg",
                "https://content.skyscnr.com/available/1215563226/1215563226_320x252.jpg",
              },
              Address =
                "111 Resorts World Avenue, Downtown Las Vegas, Las Vegas, 89109, United States",
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
