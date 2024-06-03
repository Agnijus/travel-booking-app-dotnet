using Contracts.DTOs;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Mapster;
using Services.Abstractions;


namespace Services
{
    public class HotelBookingService : IHotelBookingService
    {
        private readonly IHotelBookingRepository _hotelBookingRepository;
        public HotelBookingService(IHotelBookingRepository hotelBookingRepository)
        {
            _hotelBookingRepository = hotelBookingRepository;
        }
        public Task<HotelDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<HotelBookingDto> CreateAsync(HotelBookingForCreationDto hotelBookingForCreationDto)
        {
            var hotelBooking = hotelBookingForCreationDto.Adapt<HotelBooking>();
            _hotelBookingRepository.Insert(hotelBooking);
            return hotelBooking.Adapt<HotelBookingDto>();
        }

        public Task DeleteAsync(HotelBookingDto hotelBookingDto)
        {
            throw new NotImplementedException();
        }

       
    }
}
