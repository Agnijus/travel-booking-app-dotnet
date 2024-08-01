using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IHotelReservationDetailsRepository
    {
        Task<HotelReservation> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> AddAsync(HotelReservation hotelReservation, CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
