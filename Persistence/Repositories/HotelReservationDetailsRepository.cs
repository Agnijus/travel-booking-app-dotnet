using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class HotelReservationDetailsRepository : IHotelReservationDetailsRepository
    {
        public HotelReservationDetails GetByIdAsync(int Id)
        {
            var hotelBookings = HotelReservationDetailsData.HotelReservations.FirstOrDefault(b => b.Id == Id);
            return hotelBookings;
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
