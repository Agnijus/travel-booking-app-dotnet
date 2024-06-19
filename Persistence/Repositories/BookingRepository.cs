using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;


namespace Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public Booking GetByIdAsync(int Id)
        {
            var hotelBooking = BookingData.Bookings.FirstOrDefault(t => t.Id == Id);

            return hotelBooking;
        }

        public void Add(Booking transaction)
        {
            transaction.Id = BookingData.GetNextId();
            BookingData.Bookings.Add(transaction);
        }

        public void Delete(Booking transaction)
        {
            BookingData.Bookings.Remove(transaction);
        }
    }
}
