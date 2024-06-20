using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IHotelReservationDetailsRepository
    {
        Task<HotelReservationDetails> GetByIdAsync(int Id);
        Task<int> AddAsync(HotelReservationDetails hotelReservationDetails);
        Task DeleteAsync(HotelReservationDetails hotelReservationDetails);
    }
}
