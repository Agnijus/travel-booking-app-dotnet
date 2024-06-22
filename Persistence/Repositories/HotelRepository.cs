using travel_app.Core.Entities;
using Persistence.Data;
using travel_app.Core.Repository_Interfaces;
using Dapper;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Application.Models.Requests;
using Domain.Entities;
using Application.Models.Responses;
using Microsoft.Data.SqlClient;


namespace Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DapperContext _context;
        public HotelRepository(DapperContext context)
        {
            _context = context;
        }

        //public async Task<List<Hotel>> GetAllAsync()
        //{
        //    var query = "SELECT * FROM Hotels";

        //    using (var connection = _context.CreateConnection())
        //    {
        //        var hotelData = await connection.QueryAsync<GetHotelRequest>(query);

        //        var hotels = hotelData.Select(data => new Hotel
        //        {
        //            Id = data.Id,
        //            Name = data.Name,
        //            Images = JsonSerializer.Deserialize<string[]>(data.Images),
        //            Address = data.Address,
        //            City = data.City,
        //            Distance = data.Distance,
        //            StarRating = data.StarRating,
        //            GuestRating = data.GuestRating,
        //            ReviewCount = data.ReviewCount,
        //            HasFreeCancellation = data.HasFreeCancellation,
        //            HasPayOnArrival = data.HasPayOnArrival
        //        }).ToList();

        //        return hotels;
        //    }
        //}

        public async Task<GetHotelResponse?> GetByIdAsync(int hotelId)
        {
            var query = @"
            SELECT h.*, i.ImagePath, r.*
            FROM Hotel h
            LEFT JOIN HotelImage i ON h.HotelId = i.HotelId
            LEFT JOIN Room r ON h.HotelId = r.HotelId
            WHERE h.HotelId = @hotelId";

            using (var connection = _context.CreateConnection())
            {
                var hotelDictionary = new Dictionary<int, GetHotelResponse>();

                var result = await connection.QueryAsync<Hotel, string, Room, GetHotelResponse>(
                    query,
                    (hotel, imagePath, room) =>
                    {
                        if (!hotelDictionary.TryGetValue(hotel.HotelId, out var currentHotel))
                        {
                            currentHotel = new GetHotelResponse
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
                            hotelDictionary.Add(currentHotel.HotelId, currentHotel);
                        }

                        if (imagePath != null && !currentHotel.Images.Contains(imagePath))
                        {
                            ((List<string>)currentHotel.Images).Add(imagePath);
                        }

                        if (room != null && !((List<Room>?)currentHotel.Rooms).Any(r => r.RoomId == room.RoomId))
                        {
                            ((List<Room>)currentHotel.Rooms).Add(room);
                        }

                        return currentHotel;
                    },
                    new { HotelId = hotelId },
                    splitOn: "ImagePath,RoomId");

                return hotelDictionary.Values.FirstOrDefault();
            }
        }

        public async Task<Hotel> AddAsync(Hotel hotel)
        {
            var query = @"
            INSERT INTO Hotels (Title, Address, City, Distance, StarRating, GuestRating, ReviewCount, HasFreeCancellation, HasPayOnArrival) 
            VALUES (@Title, @Address, @City, @Distance, @StarRating, @GuestRating, @ReviewCount, @HasFreeCancellation, @HasPayOnArrival);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {

                var id = await connection.QuerySingleAsync<int>(query, hotel);
                hotel.HotelId = id;

                return hotel;
            }
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "DELETE FROM Hotels WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
               return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
