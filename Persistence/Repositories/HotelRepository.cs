using Persistence.Data;
using travel_app.Core.Repository_Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Responses;
using Microsoft.Data.SqlClient;
using System.Text.Json;


namespace Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DbContextMembers _context;
        public HotelRepository(DbContextMembers context)
        {
            _context = context;
        }

        public async Task<List<GetHotelsResponse>?> GetAllAsync()
        {

            return await _context.Database.SqlQueryRaw<GetHotelsResponse>("EXEC sp_getAllHotels_win_func")
            .ToListAsync();


            return await (from hotel in _context.Hotels
                          join image in _context.HotelImages on hotel.HotelId equals image.HotelId into images
                          from mainImage in images.Take(1).DefaultIfEmpty()
                          join room in _context.Rooms on hotel.HotelId equals room.HotelId into rooms
                          from firstRoom in rooms.OrderBy(r => r.PricePerNight).Take(1).DefaultIfEmpty()
                          select new GetHotelsResponse
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
                              Image = mainImage != null ? mainImage.ImagePath : null,
                              StartingPrice = firstRoom != null ? (ushort?)firstRoom.PricePerNight : null
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<GetHotelsResponse>?> GetByDestinationAsync(string destination)
        {
            var hotelDestinationParam = new SqlParameter("@City", destination);

            return await _context.Database.SqlQueryRaw<GetHotelsResponse>("EXEC sp_getHotelsByDestination_win_func @City", hotelDestinationParam)
                .ToListAsync();

            var query = from hotel in _context.Hotels
                        where hotel.City == destination
                        select new GetHotelsResponse
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
                            Image = _context.HotelImages
                                        .Where(i => i.HotelId == hotel.HotelId)
                                        .OrderBy(i => i.HotelImageId) 
                                        .Select(i => i.ImagePath)
                                        .FirstOrDefault(),
                            StartingPrice = _context.Rooms
                                                   .Where(r => r.HotelId == hotel.HotelId)
                                                   .OrderBy(r => r.RoomId)
                                                   .Select(r => r.PricePerNight)
                                                   .FirstOrDefault()
                        };

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<GetHotelResponse?> GetByIdAsync(int hotelId)
        {
            //var hotelIdParam = new SqlParameter("@HotelId", hotelId);

            //var hotelResponse = await _context.Database.SqlQueryRaw<GetHotelResponse>(
            //    "EXEC sp_getHotelById_json_query @HotelId",
            //    hotelIdParam
            //).ToListAsync();

            //var hotel = hotelResponse.FirstOrDefault();

            //if (hotel != null)
            //{
            //    if (hotel.Rooms != null)
            //    {
            //        Console.WriteLine(hotel.Rooms);

            //        hotel.Rooms = JsonSerializer.Deserialize<List<GetRoomResponse>>(hotel.Rooms.ToString());
            //    }
            //    else
            //    {
            //        hotel.Rooms = new List<GetRoomResponse>(); 
            //    }

            //    return hotel;
            //}

            //return null;


            return await (
                from h in _context.Hotels
                where h.HotelId == hotelId
                join hi in _context.HotelImages on h.HotelId equals hi.HotelId
                join r in _context.Rooms on h.HotelId equals r.HotelId
                join rt in _context.RoomTypes on r.RoomTypeId equals rt.RoomTypeId
                group new { hi, r, rt } by new
                {
                    h.HotelId,
                    h.Title,
                    h.Address,
                    h.City,
                    h.Distance,
                    h.StarRating,
                    h.GuestRating,
                    h.ReviewCount,
                    h.HasFreeCancellation,
                    h.HasPayOnArrival
                } into hotelGroup
                select new GetHotelResponse
                {
                    HotelId = hotelGroup.Key.HotelId,
                    Title = hotelGroup.Key.Title,
                    Address = hotelGroup.Key.Address,
                    City = hotelGroup.Key.City,
                    Distance = hotelGroup.Key.Distance,
                    StarRating = hotelGroup.Key.StarRating,
                    GuestRating = hotelGroup.Key.GuestRating,
                    ReviewCount = hotelGroup.Key.ReviewCount,
                    HasFreeCancellation = hotelGroup.Key.HasFreeCancellation,
                    HasPayOnArrival = hotelGroup.Key.HasPayOnArrival,
                    ImagePaths = hotelGroup.Select(g => g.hi.ImagePath).Distinct().ToList(),
                    Rooms = hotelGroup.Select(g => new GetRoomResponse
                    {
                        RoomTypeId = g.r.RoomTypeId,
                        PricePerNight = g.r.PricePerNight,
                        Description = g.rt.Description
                    }).Distinct().ToList()
                }
            ).FirstOrDefaultAsync();
        }



        public async Task<PostHotelResponse?> AddAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();

            return new PostHotelResponse 
            {
                HotelId = hotel.HotelId,
            };
        }
    }
}
