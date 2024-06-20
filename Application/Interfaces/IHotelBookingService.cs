using Application.Models.Requests;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IHotelBookingService
    {
        Booking GetByIdAsync(int id);
        void DeleteByIdAsync(int id);

        Booking CreateAsync(PostBookingRequest request);

    }
}
