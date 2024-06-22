using Application.Interfaces;
using Domain.Exceptions;
using Application.Models.Requests;
using travel_app.Core.Entities;
using travel_app.Core.Repository_Interfaces;
using Application.Models.Responses;


namespace Application.Services
{
    public class HotelService : IHotelService
    {

        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        //public async Task<List<Hotel>> GetAllAsync()
        //{
        //    var hotels = await _hotelRepository.GetAllAsync();

        //    return hotels;
        //}

        public async Task<GetHotelResponse> GetByIdAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            if (hotel is null)
            {
                throw new HotelNotFoundException(id);
            }

            return hotel;
        }

        //public async Task<List<Hotel>> GetByDestinationAsync(string destination)
        //{
        //    var hotels = await _hotelRepository.GetAllAsync();

        //    var filteredHotels = hotels.Where(h => h.City == destination).ToList();

        //    return filteredHotels;

        //}

        public async Task<Hotel> CreateAsync(PostHotelRequest request)
        {
            var hotel = new Hotel
            {
                Title = request.Title,
                Address = request.Address,
                City = request.City,
                Distance = request.Distance,
                StarRating = request.StarRating,
                GuestRating = request.GuestRating,
                ReviewCount = request.ReviewCount,
                HasFreeCancellation = request.HasFreeCancellation,
                HasPayOnArrival = request.HasPayOnArrival,
            };

            return await _hotelRepository.AddAsync(hotel);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var affectedRows = await _hotelRepository.DeleteByIdAsync(id);

            if (affectedRows == 0)
            {
                throw new HotelNotFoundException(id);
            }
        }
    }
}
