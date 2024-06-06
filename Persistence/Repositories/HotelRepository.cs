using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Entities;
using Persistence.Data;
using travel_booking_app_dotnet.Core.Repository_Interfaces;

namespace Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public Task<List<Hotel>> GetAllAsync()
        {
            return Task.FromResult(HotelData.Hotels);
        }

        public Task<Hotel> GetByIdAsync(int Id)
        {
            var hotel = HotelData.Hotels.FirstOrDefault(h => h.Id == Id);
            return Task.FromResult(hotel);
        }

        public void Insert(Hotel hotel)
        {
            hotel.Id = HotelData.GetNextId();
            HotelData.Hotels.Add(hotel);
        }

        public void Remove(Hotel hotel)
        {
            HotelData.Hotels.Remove(hotel);
        }
    }
}
