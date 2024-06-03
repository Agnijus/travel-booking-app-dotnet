using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Entities;
using travel_booking_app_dotnet.Core.Repository_Interfaces;
using Persistence.Data;

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
            HotelData.Hotels.Add(hotel);
        }

        public void Remove(Hotel hotel)
        {
            HotelData.Hotels.Remove(hotel);
        }
    }
}
