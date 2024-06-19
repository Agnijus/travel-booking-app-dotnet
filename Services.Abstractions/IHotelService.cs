using Contracts.DTOs;
using Domain.Entities;
using travel_booking_app_dotnet.Core.Entities;

namespace Services.Abstractions
{
    public interface IHotelService
    {
        Task<List<HotelDto>> GetAllAsync();
        Task<HotelDto> GetByIdAsync(int id);
        Task<List<HotelDto>> GetByDestinationAsync(string destination);
        Task<Hotel> CreateAsync(PostHotelRequest request);
        Task DeleteAsync(HotelDto hotelDto);

    }
}