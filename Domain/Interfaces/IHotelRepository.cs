using Application.Models.Responses;
using travel_app.Core.Entities;


namespace travel_app.Core.Repository_Interfaces
{
    public interface IHotelRepository
    {
        Task<List<GetHotelResponse>> GetAllAsync();
        Task<GetHotelResponse> GetByIdAsync(int id);
        Task<List<GetHotelResponse>> GetByDestinationAsync(string destination);
        Task<Hotel> AddAsync(Hotel hotel);
        Task<int> DeleteByIdAsync(int id);
    }
}
