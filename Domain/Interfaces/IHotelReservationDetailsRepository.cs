using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IHotelReservationDetailsRepository
    {
        HotelReservationDetails GetByIdAsync(int Id);

        void Insert(HotelReservationDetails hotelReservationDetails);
        void Remove(HotelReservationDetails hotelReservationDetails);
    }
}
