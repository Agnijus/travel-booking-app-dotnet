using Domain.Entities;
using Domain.Models.Responses;


namespace travel_app.Core.Repository_Interfaces
{
    public interface IHotelRepository
    {
        Task<List<GetHotelsResponse>?> GetAllAsync();
        Task<GetHotelResponse?> GetByIdAsync(int id);
        Task<List<GetHotelsResponse?>> GetByDestinationAsync(string destination);
        Task<Hotel?> AddAsync(Hotel hotel);
    }
}
