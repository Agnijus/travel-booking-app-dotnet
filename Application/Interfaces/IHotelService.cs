using Application.Models.Requests;
using travel_booking_app_dotnet.Core.Entities;

namespace Application.Interfaces
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int id);
        Task<List<Hotel>> GetByDestinationAsync(string destination);
        Task<Hotel> CreateAsync(PostHotelRequest request);
        Task DeleteByIdAsync(int id);
    }
}
