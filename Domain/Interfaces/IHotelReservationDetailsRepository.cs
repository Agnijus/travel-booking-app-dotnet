using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IHotelReservationDetailsRepository
    {
        HotelReservationDetails GetByIdAsync(int Id);

        void Add(HotelReservationDetails hotelReservationDetails);
        void Delete(HotelReservationDetails hotelReservationDetails);
    }
}
