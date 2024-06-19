using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Booking GetByIdAsync(int id)
        {
            var hotelBooking = _bookingRepository.GetByIdAsync(id);

            if (hotelBooking is null)
            {
                throw new BookingNotFoundException(id);
            }

            return hotelBooking;
        }

        public Booking CreateAsync(PostBookingRequest request)
        {
            var guestAccount = new GuestAccount
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                ContactNumber = request.ContactNumber
            };

            _guestAccountRepository.Insert(guestAccount);

            var hotelReservationDetails = new HotelReservationDetails
            {
                HotelId = request.HotelId,
                RoomType = request.RoomType,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                TotalPrice = request.TotalPrice,
            };

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


        public void DeleteByIdAsync(int id)
        {
            var hotelBooking = _bookingRepository.GetByIdAsync(id);

            if (hotelBooking is null)
            {
                throw new BookingNotFoundException(id);
            }

            _bookingRepository.Delete(hotelBooking);
        }
    }
}
