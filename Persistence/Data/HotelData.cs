using Domain.Entities;
using Domain.Enums;
using travel_booking_app_dotnet.Core.Entities;


namespace Persistence.Data
{
    internal class HotelData
    {
        private static int lastId = 0;

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
              Rooms = new List<Room>
              {
                new Room(1, RoomType.DoubleRoom , 173),
                new Room(2, RoomType.TwinRoom, 190),
                new Room(3, RoomType.QuadrupleRoom, 210),
              },
              Address =
                "111 Resorts World Avenue, Downtown Las Vegas, Las Vegas, 89109, United States",
              Distance = 0.8,
              StarRating = 5,
              GuestRating = 3.0f,
              ReviewCount = 731,
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
              Rooms = new List<Room>
              {
                new Room(1, RoomType.DoubleRoom , 287),
                new Room(2, RoomType.TwinRoom, 287),
                new Room(3, RoomType.QuadrupleRoom, 315),
              },
              Address =
                "3752 Las Vegas Boulevard South, Downtown Las Vegas, Las Vegas, 89158, United States",
              Distance = 0.72,
              StarRating = 5,
              GuestRating = 4.0f,
              ReviewCount = 1092,
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
              Rooms = new List<Room>
              {
                new Room(1, RoomType.DoubleRoom , 83),
                new Room(2, RoomType.TwinRoom, 90),
                new Room(3, RoomType.QuadrupleRoom, 112),


              },
              Address =
                "4500 W Tropicana Ave, Southwest Valley, Las Vegas, 89103, United States",
              Distance = 1.71,
              StarRating = 3,
              GuestRating = 3.7f,
              ReviewCount = 6816,
              HasFreeCancellation = false,
              HasPayOnArrival = true,
            }
        };

        public static int GetNextId()
        {
            return ++lastId;
        }
    }
}
