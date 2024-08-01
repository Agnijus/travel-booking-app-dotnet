using Application.Models.Requests;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IHotelBookingService
    {
        Task<Booking> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Booking> CreateAsync(PostBookingRequest request, CancellationToken cancellationToken = default);

    }
}
