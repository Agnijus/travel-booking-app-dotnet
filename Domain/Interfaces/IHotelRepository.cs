using travel_booking_app_dotnet.Core.Entities;

namespace travel_booking_app_dotnet.Core.Repository_Interfaces
{
    public interface IHotelRepository
    {
        List<Hotel> GetAllAsync();
        Hotel GetByIdAsync(int Id);

        void Add(Hotel hotel);
        void Delete(Hotel hotel);
    }
}
