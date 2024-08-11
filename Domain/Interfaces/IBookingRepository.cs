using Domain.Entities;

namespace Domain.Repository_Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(int Id);
        Task<Booking> AddAsync(Booking booking);
        Task<int?> DeleteByIdAsync(int id);
    }
}
