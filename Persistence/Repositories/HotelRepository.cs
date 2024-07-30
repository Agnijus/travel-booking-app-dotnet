using travel_app.Core.Entities;
using Persistence.Data;
using travel_app.Core.Repository_Interfaces;
using Dapper;
using Domain.Entities;
using Application.Models.Responses;
using System.Text;


namespace Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IDapperContext _context;
        public HotelRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<GetHotelResponse>> GetAllAsync()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT h.HotelId, h.Title, h.Address, h.City, h.Distance, h.StarRating, h.GuestRating, h.ReviewCount, h.HasFreeCancellation, h.HasPayOnArrival, i.ImagePath,");
            sb.AppendLine("r.RoomId, r.HotelId, r.RoomType, r.Price, r.Availability");
            sb.AppendLine("FROM Hotel h");
            sb.AppendLine("LEFT JOIN HotelImage i ON h.HotelId = i.HotelId");
            sb.AppendLine("LEFT JOIN Room r ON h.HotelId = r.HotelId");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                var hotelDictionary = new Dictionary<int, GetHotelResponse>();

                var result = await connection.QueryAsync<Hotel, string, Room, GetHotelResponse>(
                    query,
                    (hotel, imagePath, room) =>
                    {
                        if (!hotelDictionary.TryGetValue(hotel.HotelId, out var current))
                        {
                            current = new GetHotelResponse
                            {
                                HotelId = hotel.HotelId,
                                Title = hotel.Title,
                                Address = hotel.Address,
                                City = hotel.City,
                                Distance = hotel.Distance,
                                StarRating = hotel.StarRating,
                                GuestRating = hotel.GuestRating,
                                ReviewCount = hotel.ReviewCount,
                                HasFreeCancellation = hotel.HasFreeCancellation,
                                HasPayOnArrival = hotel.HasPayOnArrival,
                                Images = new List<string>(),
                                Rooms = new List<Room>()
                            };
                            hotelDictionary.Add(current.HotelId, current);
                        }

                        if (!string.IsNullOrEmpty(imagePath) && !current.Images.Contains(imagePath))
                        {
                            current.Images.Add(imagePath);
                        }

                        if (room != null && !current.Rooms.Any(r => r.RoomId == room.RoomId))
                        {
                            current.Rooms.Add(room);
                        }

                        return current;
                    },
                    splitOn: "ImagePath,RoomId");

                return hotelDictionary.Values.ToList();
            }
        }

        public async Task<List<GetHotelResponse>> GetByDestinationAsync(string destination)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT h.HotelId, h.Title, h.Address, h.City, h.Distance, h.StarRating, h.GuestRating, h.ReviewCount, h.HasFreeCancellation, h.HasPayOnArrival, i.ImagePath,");
            sb.AppendLine("r.RoomId, r.HotelId, r.RoomType, r.Price, r.Availability");
            sb.AppendLine("FROM Hotel h");
            sb.AppendLine("LEFT JOIN HotelImage i ON h.HotelId = i.HotelId");
            sb.AppendLine("LEFT JOIN Room r ON h.HotelId = r.HotelId");
            sb.AppendLine("WHERE h.City = @Destination");

            var query = sb.ToString();


            using (var connection = _context.CreateConnection())
            {
                var hotelDictionary = new Dictionary<int, GetHotelResponse>();

                var result = await connection.QueryAsync<Hotel, string, Room, GetHotelResponse>(
                    query,
                    (hotel, imagePath, room) =>
                    {
                        if (!hotelDictionary.TryGetValue(hotel.HotelId, out var current))
                        {
                            current = new GetHotelResponse
                            {
                                HotelId = hotel.HotelId,
                                Title = hotel.Title,
                                Address = hotel.Address,
                                City = hotel.City,
                                Distance = hotel.Distance,
                                StarRating = hotel.StarRating,
                                GuestRating = hotel.GuestRating,
                                ReviewCount = hotel.ReviewCount,
                                HasFreeCancellation = hotel.HasFreeCancellation,
                                HasPayOnArrival = hotel.HasPayOnArrival,
                                Images = new List<string>(),
                                Rooms = new List<Room>()
                            };
                            hotelDictionary.Add(current.HotelId, current);
                        }

                        if (!string.IsNullOrEmpty(imagePath) && !current.Images.Contains(imagePath))
                        {
                            current.Images.Add(imagePath);
                        }

                        if (room != null && !current.Rooms.Any(r => r.RoomId == room.RoomId))
                        {
                            current.Rooms.Add(room);
                        }

                        return current;
                    },
                    new { destination },

                    splitOn: "ImagePath,RoomId");

                return hotelDictionary.Values.ToList();
            }
        }

        public async Task<GetHotelResponse> GetByIdAsync(int hotelId)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT h.HotelId, h.Title, h.Address, h.City, h.Distance, h.StarRating, h.GuestRating, h.ReviewCount, h.HasFreeCancellation, h.HasPayOnArrival, i.ImagePath,");
            sb.AppendLine("r.RoomId, r.HotelId, r.RoomType, r.Price, r.Availability");
            sb.AppendLine("FROM Hotel h");
            sb.AppendLine("LEFT JOIN HotelImage i ON h.HotelId = i.HotelId");
            sb.AppendLine("LEFT JOIN Room r ON h.HotelId = r.HotelId");
            sb.AppendLine("WHERE h.HotelId = @hotelId");


            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                GetHotelResponse? response = null;

                var result = await connection.QueryAsync<Hotel, string, Room, GetHotelResponse>(
                    query,
                    (hotel, imagePath, room) =>
                    {
                        if (response == null)
                        {
                            response = new GetHotelResponse
                            {
                                HotelId = hotel.HotelId,
                                Title = hotel.Title,
                                Address = hotel.Address,
                                City = hotel.City,
                                Distance = hotel.Distance,
                                StarRating = hotel.StarRating,
                                GuestRating = hotel.GuestRating,
                                ReviewCount = hotel.ReviewCount,
                                HasFreeCancellation = hotel.HasFreeCancellation,
                                HasPayOnArrival = hotel.HasPayOnArrival,
                                Images = new List<string>(),
                                Rooms = new List<Room>()
                            };
                        }

                        if (!string.IsNullOrEmpty(imagePath) && !response.Images.Contains(imagePath))
                        {
                            response.Images.Add(imagePath);
                        }

                        if (room != null && !response.Rooms.Any(r => r.RoomId == room.RoomId))
                        {
                            response.Rooms.Add(room);
                        }

                        return response;
                    },
                    new { HotelId = hotelId },
                    splitOn: "ImagePath,RoomId");

                return response;
            }
        }

        public async Task<Hotel> AddAsync(Hotel hotel)
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO Hotel (Title, Address, City, Distance, StarRating, GuestRating, ReviewCount, HasFreeCancellation, HasPayOnArrival)");
            sb.AppendLine("VALUES (@Title, @Address, @City, @Distance, @StarRating, @GuestRating, @ReviewCount, @HasFreeCancellation, @HasPayOnArrival);");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {

                var id = await connection.QuerySingleAsync<int>(query, hotel);
                hotel.HotelId = id;

                return hotel;
            }
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var sb = new StringBuilder();

            sb.AppendLine("DELETE FROM Hotels");
            sb.AppendLine("WHERE Id = @Id");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
               return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
