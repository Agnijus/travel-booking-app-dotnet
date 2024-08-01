using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repository_Interfaces;
using Application.Models.Requests;

namespace Application.Services
{
    public class HotelBookingService : IHotelBookingService
    {
        private readonly IHotelReservationDetailsRepository _hotelReservationDetailsRepository;
        private readonly IGuestAccountRepository _guestAccountRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelBookingService(
            IHotelReservationDetailsRepository hotelReservationDetailsRepository,
            IGuestAccountRepository guestAccountRepository,
            IBookingRepository bookingRepository,
            IUnitOfWork unitOfWork)
        {
            _hotelReservationDetailsRepository = hotelReservationDetailsRepository;
            _guestAccountRepository = guestAccountRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Booking> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var hotelBooking = await _bookingRepository.GetByIdAsync(id, cancellationToken);

            if (hotelBooking is null)
            {
                throw new EntityNotFoundException(string.Format(Constant.HotelBookingNotFoundError, id));
            }

            return hotelBooking;
        }

        public async Task<Booking> CreateAsync(PostBookingRequest request, CancellationToken cancellationToken = default)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var guestAccount = new GuestAccount
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    ContactNumber = request.ContactNumber
                };

                var guestAccountId = await _guestAccountRepository.AddAsync(guestAccount, cancellationToken);

                var hotelReservationDetails = new HotelReservation
                {
                    HotelId = request.HotelId,
                    RoomTypeId = request.RoomTypeId,
                    CheckInDate = request.CheckInDate,
                    CheckOutDate = request.CheckOutDate,
                    TotalPrice = request.TotalPrice,
                };

                var hotelReservationId = await _hotelReservationDetailsRepository.AddAsync(hotelReservationDetails, cancellationToken);

                var booking = new Booking
                {
                    GuestAccountId = guestAccountId,
                    HotelReservationId = hotelReservationId,
                    TotalPrice = hotelReservationDetails.TotalPrice,
                    TransactionStatusId = 1 // Pending
                };

                var bookingResult = await _bookingRepository.AddAsync(booking, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.Commit();

                return bookingResult;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var affectedRows = await _bookingRepository.DeleteByIdAsync(id, cancellationToken);

                if (affectedRows == 0)
                {
                    throw new EntityNotFoundException(string.Format(Constant.HotelBookingNotFoundError, id));
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
