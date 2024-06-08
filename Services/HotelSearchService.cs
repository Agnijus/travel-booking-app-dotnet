using Contracts.DTOs;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Repository_Interfaces;

namespace Services
{
    public class HotelSearchService : IHotelSearchService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelSearchService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<HotelDto>> GetByDestinationAsync(string destination)
        {
            var hotels = await _hotelRepository.GetAllAsync();

            var filteredHotels = hotels.Where(h => h.City == destination).ToList();

            var hotelsDto = filteredHotels.Adapt<List<HotelDto>>();

            return hotelsDto;

        }
    }
}
