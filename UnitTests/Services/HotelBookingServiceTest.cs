
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repository_Interfaces;
using Moq;

namespace UnitTests.Services
{
    public class HotelBookingServiceTest
    {
        private readonly Mock<IHotelReservationDetailsRepository> _mockHotelReservationDetailsRepository;
        private readonly Mock<IGuestAccountRepository> _mockGuestAccountRepository;
        private readonly Mock<IBookingRepository> _mockBookingRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly HotelBookingService _service;
        public HotelBookingServiceTest()
        {
            _mockHotelReservationDetailsRepository = new Mock<IHotelReservationDetailsRepository>();
            _mockGuestAccountRepository = new Mock<IGuestAccountRepository>();
            _mockBookingRepository = new Mock<IBookingRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _service = new HotelBookingService(_mockHotelReservationDetailsRepository.Object,
                                               _mockGuestAccountRepository.Object,
                                               _mockBookingRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task GetByIdAsync_BookingExists_ReturnsBooking()
        {
            // Arrange
            var expectedBooking = new Booking
            {
                BookingId = 1,
                GuestAccountId = 100,
                HotelReservationId = 200,
                TotalPrice = 300.00,
                TransactionStatusId = 1
            };

            _mockBookingRepository.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(expectedBooking);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBooking, result);
        }
        [Fact]
        public async Task GetByIdAsync_BookingDoesntExist_ThrowsEntityNotFoundException()
        {
            // Arrange
            _mockBookingRepository.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync((Booking)null);

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
                TotalPrice = 1250.00
            };

            var guestAccountId = 2;
            var hotelReservationId = 3;

            _mockGuestAccountRepository.Setup(m => m.AddAsync(It.IsAny<GuestAccount>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(guestAccountId);
            _mockHotelReservationDetailsRepository.Setup(m => m.AddAsync(It.IsAny<HotelReservation>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(hotelReservationId);

            _mockBookingRepository.Setup(m => m.AddAsync(It.IsAny<Booking>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Booking b) => b); 

            // Act
            var result = await _service.CreateAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(guestAccountId, result.GuestAccountId);
            Assert.Equal(hotelReservationId, result.HotelReservationId);
            Assert.Equal(request.TotalPrice, result.TotalPrice);
            Assert.Equal(1, result.TransactionStatusId);
        }

        [Fact]
        public async Task DeleteByIdAsync_BookingExists_BookingDeleted()
        {
            // Arrange
            int bookingId = 1;

            _mockBookingRepository.Setup(r => r.DeleteByIdAsync(bookingId, It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            await _service.DeleteByIdAsync(bookingId);

            // Assert
            _mockBookingRepository.Verify(r => r.DeleteByIdAsync(bookingId, It.IsAny<CancellationToken>()), Times.Once(), "Should be invoked once");
        }

        [Fact]
        public async Task DeleteByIdAsync_BookingDoesntExist_ThrowsEntityNotFoundException()
        {
            // Arrange
            int bookingId = 1;
            _mockBookingRepository.Setup(r => r.DeleteByIdAsync(bookingId, It.IsAny<CancellationToken>())).ReturnsAsync(0); // 0 affected rows

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.DeleteByIdAsync(bookingId));
        }
    }
}
