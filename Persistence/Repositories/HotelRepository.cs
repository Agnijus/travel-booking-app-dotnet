using Persistence.Data;
using travel_app.Core.Repository_Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        //private readonly IDapperContext _context;
        private readonly DbContextMembers _context;
        public HotelRepository(DbContextMembers context)
        {
            _context = context;
        }

        public async Task<List<Hotel>?> GetAllAsync()
        {
            var hotels = await _context.Hotels.AsNoTracking()
                        .Select(hotel => new Hotel
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
                            HotelImages = _context.HotelImages.Where(hi => hi.HotelId == hotel.HotelId).ToList(),
                            Rooms = _context.Rooms.Where(r => r.HotelId == hotel.HotelId).ToList()
                        })
                        .ToListAsync();

            return hotels;

            //var sb = new StringBuilder();

            //sb.AppendLine("SELECT h.HotelId, h.Title, h.Address, h.City, h.Distance, h.StarRating, h.GuestRating, h.ReviewCount, h.HasFreeCancellation, h.HasPayOnArrival,");
            //sb.AppendLine("i.ImagePath,");
            //sb.AppendLine("r.RoomId, r.RoomTypeId, r.PricePerNight");
            //sb.AppendLine("FROM Hotel h");
            //sb.AppendLine("LEFT JOIN HotelImage i ON h.HotelId = i.HotelId");
            //sb.AppendLine("LEFT JOIN Room r ON h.HotelId = r.HotelId");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    var hotelDictionary = new Dictionary<int, GetHotelResponse>();

            //    var result = await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QueryAsync<Hotel, string, Room, GetHotelResponse>(
            //            query,
            //            (hotel, imagePath, room) =>
            //            {
            //                if (!hotelDictionary.TryGetValue(hotel.HotelId, out var current))
            //                {
            //                    current = new GetHotelResponse
            //                    {
            //                        HotelId = hotel.HotelId,
            //                        Title = hotel.Title,
            //                        Address = hotel.Address,
            //                        City = hotel.City,
            //                        Distance = hotel.Distance,
            //                        StarRating = hotel.StarRating,
            //                        GuestRating = hotel.GuestRating,
            //                        ReviewCount = hotel.ReviewCount,
            //                        HasFreeCancellation = hotel.HasFreeCancellation,
            //                        HasPayOnArrival = hotel.HasPayOnArrival,
            //                        Images = new List<string>(),
            //                        Rooms = new List<Room>()
            //                    };
            //                    hotelDictionary.Add(current.HotelId, current);
            //                }

            //                if (!string.IsNullOrEmpty(imagePath) && !current.Images.Contains(imagePath))
            //                {
            //                    current.Images.Add(imagePath);
            //                }

            //                if (room != null && !current.Rooms.Any(r => r.RoomId == room.RoomId))
            //                {
            //                    current.Rooms.Add(room);
            //                }

            //                return current;
            //            },
            //            splitOn: "ImagePath,RoomId"));

            //    return hotelDictionary.Values.ToList();
        
        }

        public async Task<List<Hotel?>> GetByDestinationAsync(string destination)
        {
            var hotels = await _context.Hotels.AsNoTracking()
                        .Where(h => h.City == destination)
                        .Select(hotel => new Hotel
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
                            HotelImages = _context.HotelImages.Where(hi => hi.HotelId == hotel.HotelId).ToList(),
                            Rooms = _context.Rooms.Where(r => r.HotelId == hotel.HotelId).ToList()
                        })
                        .ToListAsync();

            return hotels;


            //var sb = new StringBuilder();

            //sb.AppendLine("SELECT h.HotelId, h.Title, h.Address, h.City, h.Distance, h.StarRating, h.GuestRating, h.ReviewCount, h.HasFreeCancellation, h.HasPayOnArrival, i.ImagePath,");
            //sb.AppendLine("r.RoomId, r.RoomTypeId, r.PricePerNight");
            //sb.AppendLine("FROM Hotel h");
            //sb.AppendLine("LEFT JOIN HotelImage i ON h.HotelId = i.HotelId");
            //sb.AppendLine("LEFT JOIN Room r ON h.HotelId = r.HotelId");
            //sb.AppendLine("WHERE h.City = @destination");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    var hotelDictionary = new Dictionary<int, GetHotelResponse>();

            //    var result = await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QueryAsync<Hotel, string, Room, GetHotelResponse>(
            //            query,
            //            (hotel, imagePath, room) =>
            //            {
            //                if (!hotelDictionary.TryGetValue(hotel.HotelId, out var current))
            //                {
            //                    current = new GetHotelResponse
            //                    {
            //                        HotelId = hotel.HotelId,
            //                        Title = hotel.Title,
            //                        Address = hotel.Address,
            //                        City = hotel.City,
            //                        Distance = hotel.Distance,
            //                        StarRating = hotel.StarRating,
            //                        GuestRating = hotel.GuestRating,
            //                        ReviewCount = hotel.ReviewCount,
            //                        HasFreeCancellation = hotel.HasFreeCancellation,
            //                        HasPayOnArrival = hotel.HasPayOnArrival,
            //                        Images = new List<string>(),
            //                        Rooms = new List<Room>()
            //                    };
            //                    hotelDictionary.Add(current.HotelId, current);
            //                }

            //                if (!string.IsNullOrEmpty(imagePath) && !current.Images.Contains(imagePath))
            //                {
            //                    current.Images.Add(imagePath);
            //                }

            //                if (room != null && !current.Rooms.Any(r => r.RoomId == room.RoomId))
            //                {
            //                    current.Rooms.Add(room);
            //                }

            //                return current;
            //            },
            //            new { destination },
            //            splitOn: "ImagePath,RoomId"));

            //    return hotelDictionary.Values.ToList();
    
        }

        public async Task<Hotel?> GetByIdAsync(int hotelId)
        {
            var hotel = await _context.Hotels.AsNoTracking()
                        .Where(h => h.HotelId == hotelId)
                        .Select(h => new Hotel
                        {
                            HotelId = h.HotelId,
                            Title = h.Title,
                            Address = h.Address,
                            City = h.City,
                            Distance = h.Distance,
                            StarRating = h.StarRating,
                            GuestRating = h.GuestRating,
                            ReviewCount = h.ReviewCount,
                            HasFreeCancellation = h.HasFreeCancellation,
                            HasPayOnArrival = h.HasPayOnArrival,
                            HotelImages = _context.HotelImages
                                .Where(hi => hi.HotelId == h.HotelId)
                                .ToList(),
                            Rooms = _context.Rooms
                                .Where(r => r.HotelId == h.HotelId)
                                .ToList()
                        })
                        .FirstOrDefaultAsync();


            return hotel;

            //var sb = new StringBuilder();

            //sb.AppendLine("SELECT h.HotelId, h.Title, h.Address, h.City, h.Distance, h.StarRating, h.GuestRating, h.ReviewCount, h.HasFreeCancellation, h.HasPayOnArrival, i.ImagePath,");
            //sb.AppendLine("r.RoomId, r.RoomTypeId, r.PricePerNight");
            //sb.AppendLine("FROM Hotel h");
            //sb.AppendLine("LEFT JOIN HotelImage i ON h.HotelId = i.HotelId");
            //sb.AppendLine("LEFT JOIN Room r ON h.HotelId = r.HotelId");
            //sb.AppendLine("WHERE h.HotelId = @hotelId");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    GetHotelResponse? response = null;

            //    var result = await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QueryAsync<Hotel, string, Room, GetHotelResponse>(
            //            query,
            //            (hotel, imagePath, room) =>
            //            {
            //                if (response == null)
            //                {
            //                    response = new GetHotelResponse
            //                    {
            //                        HotelId = hotel.HotelId,
            //                        Title = hotel.Title,
            //                        Address = hotel.Address,
            //                        City = hotel.City,
            //                        Distance = hotel.Distance,
            //                        StarRating = hotel.StarRating,
            //                        GuestRating = hotel.GuestRating,
            //                        ReviewCount = hotel.ReviewCount,
            //                        HasFreeCancellation = hotel.HasFreeCancellation,
            //                        HasPayOnArrival = hotel.HasPayOnArrival,
            //                        Images = new List<string>(),
            //                        Rooms = new List<Room>()
            //                    };
            //                }

            //                if (!string.IsNullOrEmpty(imagePath) && !response.Images.Contains(imagePath))
            //                {
            //                    response.Images.Add(imagePath);
            //                }

            //                if (room != null && !response.Rooms.Any(r => r.RoomId == room.RoomId))
            //                {
            //                    response.Rooms.Add(room);
            //                }

            //                return response;
            //            },
            //            new { hotelId },
            //            splitOn: "ImagePath,RoomId"));

            //    return response;
            //}
        }

        public async Task<Hotel?> AddAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return hotel;

            //var sb = new StringBuilder();

            //sb.AppendLine("INSERT INTO Hotel (Title, Address, City, Distance, StarRating, GuestRating, ReviewCount, HasFreeCancellation, HasPayOnArrival)");
            //sb.AppendLine("VALUES (@Title, @Address, @City, @Distance, @StarRating, @GuestRating, @ReviewCount, @HasFreeCancellation, @HasPayOnArrival);");
            //sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    var id = await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QuerySingleAsync<int>(query, hotel));
            //    hotel.HotelId = id;
            //    return hotel;
            //}
        }

        public async Task<int?> DeleteByIdAsync(int id)
        {
            var hotel = await (from h in _context.Hotels.AsNoTracking()
                               where h.HotelId == id
                               select h).FirstOrDefaultAsync();

            //var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
            {
                return null;
            }

            _context.Hotels.Remove(hotel);
            return await _context.SaveChangesAsync();


            //var sb = new StringBuilder();

            //sb.AppendLine("DELETE FROM Hotel");
            //sb.AppendLine("WHERE HotelId = @Id");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    return await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.ExecuteAsync(query, new { Id = id }));
            //}
        }
    }
}
