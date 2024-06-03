using Contracts.DTOs;
using Services.Abstractions;
using Persistence.Repositories;
using travel_booking_app_dotnet.Core.Repository_Interfaces;
using Mapster;
using Domain.Exceptions;
using travel_booking_app_dotnet.Core.Entities;

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

        public async Task<HotelDto> GetByIdAsync(uint id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            if (hotel is null)
            {
                throw new HotelNotFoundException(id);
            }

            var hotelDto = hotel.Adapt<HotelDto>();

            return hotelDto;
        }

        public Task CreateAsync(HotelDto hotelDto)
        {
            var hotel = hotelDto.Adapt<Hotel>();

            _hotelRepository.Insert(hotel);

            return Task.CompletedTask;

        }

        public async Task DeleteAsync(HotelDto hotelDto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(hotelDto.Id);

            if(hotel is null)
            {
                throw new HotelNotFoundException(hotelDto.Id);
            }

            _hotelRepository.Remove(hotel);
        }
    }
}