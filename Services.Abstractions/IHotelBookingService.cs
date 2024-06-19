using Contracts.DTOs;
using Domain.Entities;

namespace Services.Abstractions
{
    public interface IHotelBookingService
    {
        Task<BookingDto> GetByIdAsync(int id);
        Task DeleteByIdAsync(int  id);

        Task<Booking> CreateAsync(GuestAccount guestAccount, HotelReservationDetails hotelReservationDetails);

    }
}
