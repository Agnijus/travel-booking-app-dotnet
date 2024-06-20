using Application.Models.Requests;
using travel_booking_app_dotnet.Core.Entities;

namespace Application.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAllAsync();
        Hotel GetByIdAsync(int id);
        List<Hotel> GetByDestinationAsync(string destination);
        Hotel CreateAsync(PostHotelRequest request);
        void DeleteByIdAsync(int id);
    }
}
