using Domain.Entities;


namespace travel_app.Core.Repository_Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>?> GetAllAsync();
        Task<Hotel?> GetByIdAsync(int id);
        Task<List<Hotel?>> GetByDestinationAsync(string destination);
        Task<Hotel?> AddAsync(Hotel hotel);
        Task<int?> DeleteByIdAsync(int id);
    }
}
