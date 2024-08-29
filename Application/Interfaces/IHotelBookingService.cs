using Application.Models.Requests;
using Domain.Entities;
using Domain.Models.Responses;


namespace Application.Interfaces
{
    public interface IHotelBookingService
    {
        Task<GetBookingResponse> GetByIdAsync(int id);
        Task<PostBookingResponse> CreateAsync(PostBookingRequest request);
    }
}
