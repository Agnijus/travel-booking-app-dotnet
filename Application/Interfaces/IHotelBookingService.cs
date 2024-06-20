using Application.Models.Requests;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IHotelBookingService
    {
        Task<Booking> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);

        Task<Booking> CreateAsync(PostBookingRequest request);

    }
}
