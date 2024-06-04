using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IHotelBookingRepository
    {
        Task<HotelBooking> GetByIdAsync(int Id);

        void Insert(HotelBooking hotelBooking);
        void Remove(HotelBooking hotelBooking);
    }
}
