using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;


namespace Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public Task<Booking> GetByIdAsync(int Id)
        {
            var hotelBooking = BookingData.Bookings.FirstOrDefault(t => t.Id == Id);
            return Task.FromResult(hotelBooking);
        }

        public void Insert(Booking transaction)
        {
            transaction.Id = BookingData.GetNextId();
            BookingData.Bookings.Add(transaction);
        }

        public void Remove(Booking transaction)
        {
            BookingData.Bookings.Remove(transaction);
        }
    }
}
