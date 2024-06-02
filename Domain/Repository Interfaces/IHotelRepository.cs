using travel_booking_app_dotnet.Core.Entities;

namespace travel_booking_app_dotnet.Core.Repository_Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(uint Id);

        void Insert(Hotel hotel);
        void Remove(Hotel hotel);
    }
}
