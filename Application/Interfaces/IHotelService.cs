using Application.Models.Requests;
using Domain.Entities;
using Domain.Models.Responses;

namespace Application.Interfaces
{
    public interface IHotelService
    {
        Task<List<GetHotelsResponse>> GetAllAsync();
        Task<GetHotelResponse> GetByIdAsync(int id);
        Task<List<GetHotelsResponse>> GetByDestinationAsync(string destination);
        Task<Hotel> CreateAsync(PostHotelRequest request);
    }
}