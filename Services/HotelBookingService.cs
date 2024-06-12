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
        private readonly IValidator<GuestAccountHotelBookingDto> _validator;



        public HotelBookingService(IHotelReservationDetailsRepository hotelReservationDetailsRepository, IGuestAccountRepository guestAccountRepository, IBookingRepository
            bookingRepository, IValidator<GuestAccountHotelBookingDto> validator)
        {
            _hotelReservationDetailsRepository = hotelReservationDetailsRepository;
            _guestAccountRepository = guestAccountRepository;
            _bookingRepository = bookingRepository;
            _validator = validator;
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

        public async Task<BookingDto> CreateAsync(GuestAccountHotelBookingDto guestAccountHotelBookingDto)
        {

            var validationResult = await _validator.ValidateAsync(guestAccountHotelBookingDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }


            var guestAccount = new GuestAccount
            {
                FirstName = guestAccountHotelBookingDto.FirstName,
                LastName = guestAccountHotelBookingDto.LastName,
                Email = guestAccountHotelBookingDto.Email,
                ContactNumber = guestAccountHotelBookingDto.ContactNumber
            };

            _guestAccountRepository.Insert(guestAccount);

            var hotelReservationDetails = new HotelReservationDetails
            {
                HotelId = guestAccountHotelBookingDto.HotelId,
                RoomType = guestAccountHotelBookingDto.RoomType,
                CheckInDate = guestAccountHotelBookingDto.CheckInDate,
                CheckOutDate = guestAccountHotelBookingDto.CheckOutDate,
                TotalPrice = (double)guestAccountHotelBookingDto.TotalPrice,
            };

           
            _hotelReservationDetailsRepository.Insert(hotelReservationDetails);

            var booking = new Booking
            {
                AccountId = guestAccount.Id,
                ReservationId = hotelReservationDetails.Id,
                TotalPrice = hotelReservationDetails.TotalPrice,
                Status = TransactionStatus.Pending
            };

            _bookingRepository.Insert(booking);

            return booking.Adapt<BookingDto>();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var hotelBooking = await _bookingRepository.GetByIdAsync(id);

            if (hotelBooking is null)
            {
                throw new BookingNotFoundException(id);
            }

            _bookingRepository.Remove(hotelBooking);
        }
    }
}
