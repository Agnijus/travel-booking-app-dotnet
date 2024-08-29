using Domain.Entities;
using Domain.Models.Responses;

namespace Domain.Repository_Interfaces
{
    public interface IBookingRepository
    {
        Task<GetBookingResponse?> GetByIdAsync(int Id);
        Task<PostBookingResponse> AddAsync(Booking booking);
    }
}
