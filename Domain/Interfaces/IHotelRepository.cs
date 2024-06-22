using travel_app.Core.Entities;

namespace travel_app.Core.Repository_Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int Id);
        Task<Hotel> AddAsync(Hotel hotel);
        Task DeleteAsync(int id);
    }
}
