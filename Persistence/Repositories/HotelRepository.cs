using Persistence.Data;
using travel_app.Core.Repository_Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Responses;

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

            return await (from hotel in _context.Hotels
                          join image in _context.HotelImages on hotel.HotelId equals image.HotelId into images
                          from mainImage in images.Take(1).DefaultIfEmpty() 
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
                              Image = mainImage != null ? mainImage.ImagePath : null
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<GetHotelsResponse>?> GetByDestinationAsync(string destination)
        {
            return await (from hotel in _context.Hotels
                          where hotel.City == destination
                          join image in _context.HotelImages on hotel.HotelId equals image.HotelId into images
                          from mainImage in images.Take(1).DefaultIfEmpty()
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
                              Image = mainImage != null ? mainImage.ImagePath : null
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<GetHotelResponse?> GetByIdAsync(int hotelId)
        {
            return await (from h in _context.Hotels
                          where h.HotelId == hotelId
                          select new GetHotelResponse
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
                              ImagePaths = (from i in _context.HotelImages
                                            where i.HotelId == h.HotelId
                                            select i.ImagePath).ToList(),
                              Rooms = (from r in _context.Rooms
                                       join rt in _context.RoomTypes on r.RoomTypeId equals rt.RoomTypeId
                                       where r.HotelId == h.HotelId
                                       select new GetRoomResponse
                                       {
                                           Description = rt.Description,
                                           PricePerNight = r.PricePerNight
                                       }).ToList()
                          }).AsNoTracking().FirstOrDefaultAsync();
        }


        public async Task<Hotel?> AddAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
