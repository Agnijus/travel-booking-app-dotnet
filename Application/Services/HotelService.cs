using Application.Interfaces;
using Domain.Exceptions;
using Application.Models.Requests;
using travel_app.Core.Entities;
using travel_app.Core.Repository_Interfaces;
using Application.Models.Responses;
using Application.Models;


namespace Application.Services
{
    public class HotelService : IHotelService
    {

        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<GetHotelResponse>> GetAllAsync()
        {
            var hotels = await _hotelRepository.GetAllAsync();

            if(hotels.Count == 0)
            {
                throw new EntityNotFoundException(string.Format(Constant.HotelsNotFoundError));
            }

            return hotels;
        }

        public async Task<GetHotelResponse> GetByIdAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            if (hotel is null)
            {
                throw new EntityNotFoundException(string.Format(Constant.HotelNotFoundError, id));
            }

            return hotel;
        }

        public async Task<List<GetHotelResponse>> GetByDestinationAsync(string destination)
        {
            var hotels = await _hotelRepository.GetByDestinationAsync(destination);

            if (hotels.Count == 0)
            {
                throw new EntityNotFoundException(string.Format(Constant.HotelDestinationNotFoundError, destination));
            }

            return hotels;
        }

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
                throw new EntityNotFoundException(string.Format(Constant.HotelNotFoundError, id));
            }
        }
    }
}
