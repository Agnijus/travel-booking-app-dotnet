using Contracts.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repository_Interfaces;
using FluentValidation;
using Mapster;
using Services.Abstractions;
using Services.Validators;


namespace Services
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
        public async Task<BookingDto> GetByIdAsync(int id)
        {
            var hotelBooking = await _bookingRepository.GetByIdAsync(id);

            if (hotelBooking is null)
            {
                throw new BookingNotFoundException(id);
            }

            var hotelBookingDto = hotelBooking.Adapt<BookingDto>();

            return hotelBookingDto;
        }

        public async Task<Booking> CreateAsync(GuestAccount guestAccount, HotelReservationDetails hotelReservationDetails)
        {
            _guestAccountRepository.Insert(guestAccount);

            _hotelReservationDetailsRepository.Insert(hotelReservationDetails);

            var booking = new Booking
            {
                AccountId = guestAccount.Id,
                ReservationId = hotelReservationDetails.Id,
                TotalPrice = hotelReservationDetails.TotalPrice,
                Status = TransactionStatus.Pending
            };

            _bookingRepository.Add(booking);

            return booking;
        }


        public async Task DeleteByIdAsync(int id)
        {
            var hotelBooking = await _bookingRepository.GetByIdAsync(id);

            if (hotelBooking is null)
            {
                throw new BookingNotFoundException(id);
            }

            _bookingRepository.Delete(hotelBooking);
        }
    }
}