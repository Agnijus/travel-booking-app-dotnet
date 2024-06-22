using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repository_Interfaces;


namespace Application.Services
{
    public class HotelBookingService : IHotelBookingService
    {

        private readonly IHotelReservationDetailsRepository _hotelReservationDetailsRepository;
        private readonly IGuestAccountRepository _guestAccountRepository;
        private readonly IBookingRepository _bookingRepository;



        public HotelBookingService(IHotelReservationDetailsRepository hotelReservationDetailsRepository, IGuestAccountRepository guestAccountRepository, IBookingRepository
            bookingRepository)
        {
            _hotelReservationDetailsRepository = hotelReservationDetailsRepository;
            _guestAccountRepository = guestAccountRepository;
            _bookingRepository = bookingRepository;
        }
        public async Task<Booking> GetByIdAsync(int id)
        {
            var hotelBooking = await _bookingRepository.GetByIdAsync(id);

            if (hotelBooking is null)
            {
                throw new BookingNotFoundException(id);
            }

            return hotelBooking;
        }

        public async Task<Booking> CreateAsync(PostBookingRequest request)
        {
            var guestAccount = new GuestAccount
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                ContactNumber = request.ContactNumber
            };

            var guestAccountId = await _guestAccountRepository.AddAsync(guestAccount);

            var hotelReservationDetails = new HotelReservation
            {
                HotelId = request.HotelId,
                RoomTypeId = request.RoomTypeId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                TotalPrice = request.TotalPrice,
            };

            var hotelReservationId = await _hotelReservationDetailsRepository.AddAsync(hotelReservationDetails);

            var booking = new Booking
            {
                GuestAccountId = guestAccountId,
                HotelReservationId = hotelReservationId,
                TotalPrice = hotelReservationDetails.TotalPrice,
                TransactionStatusId = 0
            };

            var createdBooking = await _bookingRepository.AddAsync(booking);

            return createdBooking;
        }


        public async Task DeleteByIdAsync(int id)
        {
            var affectedRows = await _bookingRepository.DeleteByIdAsync(id);

            if (affectedRows == 0)
            {
                throw new BookingNotFoundException(id);
            }
        }
    }
}
