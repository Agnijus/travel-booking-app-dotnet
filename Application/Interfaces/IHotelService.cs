using Application.Models.Requests;
using travel_app.Core.Entities;

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
