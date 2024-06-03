using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class HotelBookingRepository : IHotelBookingRepository
    {
        public Task<HotelBooking> GetByIdAsync(int Id)
        {
            var hotelBookings = HotelBookingData.HotelBookings.FirstOrDefault(b => b.Id == Id);
            return Task.FromResult(hotelBookings);
        }

        public void Insert(HotelBooking hotelBooking)
        {
            HotelBookingData.HotelBookings.Add(hotelBooking);
        }

        public void Remove(HotelBooking hotelBooking)
        {
            HotelBookingData.HotelBookings.Remove(hotelBooking);
        }
    }
}
