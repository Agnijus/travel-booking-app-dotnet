using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;
using System.Transactions;

namespace Persistence.Repositories
{
    public class HotelReservationDetailsRepository : IHotelReservationDetailsRepository
    {
        public Task<HotelReservationDetails> GetByIdAsync(int Id)
        {
            var hotelBookings = HotelReservationDetailsData.HotelReservations.FirstOrDefault(b => b.Id == Id);
            return Task.FromResult(hotelBookings);
        }

        public void Insert(HotelReservationDetails hotelBooking)
        {
            hotelBooking.Id = HotelReservationDetailsData.GetNextId();
            HotelReservationDetailsData.HotelReservations.Add(hotelBooking);
        }

        public void Remove(HotelReservationDetails hotelBooking)
        {
            HotelReservationDetailsData.HotelReservations.Remove(hotelBooking);
        }
    }
}
