using Contracts.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repository_Interfaces;
using Mapster;
using Services.Abstractions;


namespace Services
{
    public class HotelBookingService : IHotelBookingService
    {
        private readonly IHotelBookingRepository _hotelBookingRepository;
        private readonly IGuestAccountRepository _guestAccountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public HotelBookingService(IHotelBookingRepository hotelBookingRepository, IGuestAccountRepository guestAccountRepository, ITransactionRepository 
            transactionRepository)
        {
            _hotelBookingRepository = hotelBookingRepository;
            _guestAccountRepository = guestAccountRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task<TransactionDto> GetByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction is null)
            {
                throw new TransactionNotFoundException(id);
            }

            var transactionDto = transaction.Adapt<TransactionDto>();

            return transactionDto;
        }

        public async Task<TransactionDto> CreateAsync(GuestAccountHotelBookingDto guestAccountHotelBookingDto)
        {
            var guestAccount = new GuestAccount
            {
                FirstName = guestAccountHotelBookingDto.FirstName,
                LastName = guestAccountHotelBookingDto.LastName,
                Email = guestAccountHotelBookingDto.Email,
                ContactNumber = guestAccountHotelBookingDto.PhoneNumber
            };

            _guestAccountRepository.Insert(guestAccount);

            var hotelBooking = new HotelBooking
            {
                HotelId = guestAccountHotelBookingDto.HotelId,
                RoomType = guestAccountHotelBookingDto.RoomType,
                CheckInDate = guestAccountHotelBookingDto.CheckInDate,
                CheckOutDate = guestAccountHotelBookingDto.CheckOutDate,
                TotalPrice = (double)guestAccountHotelBookingDto.TotalPrice,
            };

            _hotelBookingRepository.Insert(hotelBooking);

            var transaction = new Transaction
            {
                AccountId = guestAccount.Id,
                BookingId = hotelBooking.Id,
                TotalPrice = hotelBooking.TotalPrice,
                Status = TransactionStatus.Pending
            };

            _transactionRepository.Insert(transaction);

            return transaction.Adapt<TransactionDto>();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction is null)
            {
                throw new TransactionNotFoundException(id);
            }

            _transactionRepository.Remove(transaction);
        }
    }
}
