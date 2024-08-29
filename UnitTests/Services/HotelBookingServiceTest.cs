
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Models.Responses;
using Domain.Repository_Interfaces;
using Moq;

namespace UnitTests.Services
{
    public class HotelBookingServiceTest
    {
        private readonly Mock<IHotelReservationDetailsRepository> _mockHotelReservationDetailsRepository;
        private readonly Mock<IGuestAccountRepository> _mockGuestAccountRepository;
        private readonly Mock<IBookingRepository> _mockBookingRepository;
        private readonly HotelBookingService _service;
        public HotelBookingServiceTest()
        {
            _mockHotelReservationDetailsRepository = new Mock<IHotelReservationDetailsRepository>();
            _mockGuestAccountRepository = new Mock<IGuestAccountRepository>();
            _mockBookingRepository = new Mock<IBookingRepository>();
            _service = new HotelBookingService(_mockHotelReservationDetailsRepository.Object,
                                               _mockGuestAccountRepository.Object,
                                               _mockBookingRepository.Object);
        }

        [Fact]
        public async Task GetByIdAsync_BookingExists_ReturnsBooking()
        {
            // Arrange
            var booking = new GetBookingResponse
            {
                BookingId = 1,
                FullName = "Agnijus Botyrius",
                HotelTitle = "Hotel A",
                CheckInDate = new DateTime(2024, 08, 10),
                CheckOutDate = new DateTime(2024, 08, 29),
                TotalPrice = 1200,
                TransactionStatus = "Pending"
            };

            _mockBookingRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(booking);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(booking, result);
        }

        [Fact]
        public async Task GetByIdAsync_BookingDoesntExist_ThrowsEntityNotFoundException()
        {
            // Arrange
            _mockBookingRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((GetBookingResponse)null);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetByIdAsync(1));
        }

        [Fact]
        public async Task CreateAsync_ValidRequest_ReturnsBooking()
        {
            // Arrange
            var request = new PostBookingRequest
            {
                FirstName = "Agnijus",
                LastName = "Botyrius",
                Email = "agnijus@gmail.com",
                ContactNumber = "123456789",
                HotelId = 1,
                RoomTypeId = 1,
                CheckInDate = new DateTime(2024, 7, 7),
                CheckOutDate = new DateTime(2024, 7, 24),
                TotalPrice = 1250
            };

            var guestAccountId = 2;
            var hotelReservationId = 3;

            _mockGuestAccountRepository.Setup(m => m.AddAsync(It.IsAny<GuestAccount>()))
                .ReturnsAsync(guestAccountId);
            _mockHotelReservationDetailsRepository.Setup(m => m.AddAsync(It.IsAny<HotelReservation>()))
                .ReturnsAsync(hotelReservationId);

            _mockBookingRepository.Setup(m => m.AddAsync(It.IsAny<Booking>()))
            .ReturnsAsync((PostBookingResponse b) => b);

            // Act
            var result = await _service.CreateAsync(request);

            // Assert
            Assert.NotNull(result);
        }
    }
}
