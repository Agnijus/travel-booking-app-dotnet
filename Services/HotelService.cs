using Contracts.DTOs;
using Services.Abstractions;
using Persistence.Repositories;
using travel_booking_app_dotnet.Core.Repository_Interfaces;
using Mapster;
using Domain.Exceptions;
using travel_booking_app_dotnet.Core.Entities;
using FluentValidation;
using Domain.Entities;

namespace Services
{
    public class HotelService : IHotelService
    {

        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<HotelDto>> GetAllAsync()
        {
            var hotels = await _hotelRepository.GetAllAsync();

            var hotelsDto = hotels.Adapt<List<HotelDto>>();

            return hotelsDto;
        }

        public async Task<HotelDto> GetByIdAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            if (hotel is null)
            {
                throw new HotelNotFoundException(id);
            }

            var hotelDto = hotel.Adapt<HotelDto>();

            return hotelDto;
        }

        public async Task<List<HotelDto>> GetByDestinationAsync(string destination)
        {
            var hotels = await _hotelRepository.GetAllAsync();

            var filteredHotels = hotels.Where(h => h.City == destination).ToList();

            var hotelsDto = filteredHotels.Adapt<List<HotelDto>>();

            return hotelsDto;

        }

        public async Task<Hotel> CreateAsync(PostHotelRequest request)
        {
            var hotel = new Hotel
            {
                Name = request.Name,
                Images = request.Images,
                Address = request.Address,
                City = request.City,
                Distance = request.Distance,
                StarRating = request.StarRating,
                GuestRating = request.GuestRating,
                ReviewCount = request.ReviewCount,
                HasFreeCancellation = request.HasFreeCancellation,
                HasPayOnArrival = request.HasPayOnArrival,
                Rooms = request.Rooms
            };

            _hotelRepository.Add(hotel);

            return hotel;
        }

        public async Task DeleteAsync(HotelDto hotelDto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(hotelDto.Id);

            if(hotel is null)
            {
                throw new HotelNotFoundException(hotelDto.Id);
            }

            _hotelRepository.Delete(hotel);
        }
    }
}