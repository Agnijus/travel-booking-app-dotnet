using Domain.Entities;

namespace Domain.Repository_Interfaces
{
    public interface IBookingRepository
    {
        Booking GetByIdAsync(int Id);

        void Add(Booking booking);
        void Delete(Booking booking);
    }
}
