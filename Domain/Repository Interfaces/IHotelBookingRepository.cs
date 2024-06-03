using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IHotelBookingRepository
    {
        Task<HotelBooking> GetByIdAsync(int Id);

        void Insert(HotelBooking hotel);
        void Remove(HotelBooking hotel);
    }
}
