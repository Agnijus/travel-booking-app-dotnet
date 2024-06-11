using Contracts.DTOs;

namespace Services.Abstractions
{
    public interface IHotelService
    {
        Task<List<HotelDto>> GetAllAsync();
        Task<HotelDto> GetByIdAsync(int id);
        Task<List<HotelDto>> GetByDestinationAsync(string destination);
        Task<HotelDto> CreateAsync(HotelDto hotelForCreationDto);
        Task DeleteAsync(HotelDto hotelDto);

    }
}