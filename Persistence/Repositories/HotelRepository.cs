using travel_booking_app_dotnet.Core.Entities;
using Persistence.Data;
using travel_booking_app_dotnet.Core.Repository_Interfaces;
using Dapper;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Application.Models.Requests;


namespace Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DapperContext _context;
        public HotelRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAllAsync()
        {
            var query = "SELECT * FROM Hotels";

            using (var connection = _context.CreateConnection())
            {
                var hotelData = await connection.QueryAsync<GetHotelRequest>(query);

                var hotels = hotelData.Select(data => new Hotel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Images = JsonSerializer.Deserialize<string[]>(data.Images),
                    Address = data.Address,
                    City = data.City,
                    Distance = data.Distance,
                    StarRating = data.StarRating,
                    GuestRating = data.GuestRating,
                    ReviewCount = data.ReviewCount,
                    HasFreeCancellation = data.HasFreeCancellation,
                    HasPayOnArrival = data.HasPayOnArrival
                }).ToList();

                return hotels;
            }
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Hotels WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<GetHotelRequest>(query, new { Id = id });

                var hotel = new Hotel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Images = JsonSerializer.Deserialize<string[]>(data.Images),
                    Address = data.Address,
                    City = data.City,
                    Distance = data.Distance,
                    StarRating = data.StarRating,
                    GuestRating = data.GuestRating,
                    ReviewCount = data.ReviewCount,
                    HasFreeCancellation = data.HasFreeCancellation,
                    HasPayOnArrival = data.HasPayOnArrival
                };

                return hotel;
            }
        }

        public async Task<Hotel> AddAsync(Hotel hotel)
        {
            var query = @"
            INSERT INTO Hotels (Name, Images, Address, City, Distance, StarRating, GuestRating, ReviewCount, HasFreeCancellation, HasPayOnArrival) 
            VALUES (@Name, @Images, @Address, @City, @Distance, @StarRating, @GuestRating, @ReviewCount, @HasFreeCancellation, @HasPayOnArrival);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    hotel.Name,
                    Images = JsonSerializer.Serialize(hotel.Images),
                    hotel.Address,
                    hotel.City,
                    hotel.Distance,
                    hotel.StarRating,
                    hotel.GuestRating,
                    hotel.ReviewCount,
                    hotel.HasFreeCancellation,
                    hotel.HasPayOnArrival
                };

                var id = await connection.QuerySingleAsync<int>(query, parameters);
                hotel.Id = id;

                var selectQuery = "SELECT * FROM Hotels WHERE Id = @Id";
                var data = await connection.QueryFirstOrDefaultAsync<GetHotelRequest>(selectQuery, new { Id = id });

                hotel.Images = JsonSerializer.Deserialize<string[]>(data.Images);
                return hotel;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM Hotels WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
