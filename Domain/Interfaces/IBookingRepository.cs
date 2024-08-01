using Domain.Entities;

namespace Domain.Repository_Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Booking> AddAsync(Booking booking, CancellationToken cancellationToken = default);
        Task<int> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
