using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IHotelReservationDetailsRepository
    {
        Task<HotelReservation?> GetByIdAsync(int Id);
        Task<int> AddAsync(HotelReservation hotelReservationDetails);
    }
}
