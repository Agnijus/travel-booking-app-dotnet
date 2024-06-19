using travel_booking_app_dotnet.Core.Entities;
using Persistence.Data;
using travel_booking_app_dotnet.Core.Repository_Interfaces;

namespace Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public List<Hotel> GetAllAsync()
        {
            return HotelData.Hotels;
        }

        public Hotel GetByIdAsync(int Id)
        {
            var hotel = HotelData.Hotels.FirstOrDefault(h => h.Id == Id);
            return hotel;
        }

        public void Add(Hotel hotel)
        {
            hotel.Id = HotelData.GetNextId();
            HotelData.Hotels.Add(hotel);
        }

        public void Delete(Hotel hotel)
        {
            HotelData.Hotels.Remove(hotel);
        }
    }
}
