using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IHotelReservationDetailsRepository
    {
        Task<HotelReservationDetails> GetByIdAsync(int Id);

        void Insert(HotelReservationDetails hotelReservationDetails);
        void Remove(HotelReservationDetails hotelReservationDetails);
    }
}
