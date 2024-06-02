using Contracts.DTOs;

namespace Services.Abstractions
{
    public interface IHotelService
    {
        Task<List<HotelDto>> GetAllAsync();
        Task<HotelDto> GetByIdAsync(uint id);
        Task CreateAsync(HotelDto hotelDto);
        Task DeleteAsync(HotelDto hotelDto);
    }
}