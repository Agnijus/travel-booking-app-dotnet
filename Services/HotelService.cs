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
        private readonly IValidator<HotelDto> _hotelValidator;
        public HotelService(IHotelRepository hotelRepository, IValidator<HotelDto> hotelValidator)
        {
            _hotelRepository = hotelRepository;
            _hotelValidator = hotelValidator;
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

        public async Task<HotelDto> CreateAsync(HotelDto hotelDto)
        {
            var validationResult = await _hotelValidator.ValidateAsync(hotelDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var hotel = hotelDto.Adapt<Hotel>();

            _hotelRepository.Insert(hotel);

            return hotel.Adapt<HotelDto>();
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