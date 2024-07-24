
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Services;
using Domain.Exceptions;
using Moq;
using travel_app.Core.Entities;
using travel_app.Core.Repository_Interfaces;

namespace UnitTests.Services
{
    public class HotelServiceTest
    {
        private readonly Mock<IHotelRepository> _mockHotelRepository;
        private readonly HotelService _service;

        public HotelServiceTest()
        {
            _mockHotelRepository = new Mock<IHotelRepository>();
            _service = new HotelService(_mockHotelRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_HotelsExist_ReturnsHotels()
        {
            // Arrange
            var hotels = new List<GetHotelResponse>
            {
                new GetHotelResponse { HotelId = 1, Title = "Hotel One" },
                new GetHotelResponse { HotelId = 2, Title = "Hotel Two" }
            };

            _mockHotelRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(hotels);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(hotels);
            Assert.Equal(hotels, result);
        }

        [Fact]
        public async Task GetAllAsync_NoHotelsExist_ThrowsEntityNotFoundException()
        {
            // Arrange
            var hotelList = new List<GetHotelResponse>();

            _mockHotelRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(hotelList);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetAllAsync());
        }

        [Fact]
        public async Task GetByIdAsync_HotelExists_ReturnsHotel()
        {
            // Arrange
            var hotel = new GetHotelResponse { HotelId = 1, Title = "Hotel A" };
            _mockHotelRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(hotel);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(hotel, result);
        }

        [Fact]
        public async Task GetByIdAsync_HotelDoesntExist_ThrowsEntityNotFoundException()
        {
            // Arrange
            _mockHotelRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((GetHotelResponse)null);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetByIdAsync(1));
        }

        [Fact]
        public async Task GetByDestinationAsync_HotelsExist_ReturnsHotels()
        {
            // Arrange
            var hotels = new List<GetHotelResponse>
            {
                new GetHotelResponse { HotelId = 1, Title = "Hotel A", City = "London" },
                new GetHotelResponse { HotelId = 2, Title = "Hotel B", City = "London" }
            };

            _mockHotelRepository.Setup(r => r.GetByDestinationAsync("London")).ReturnsAsync(hotels);

            // Act
            var result = await _service.GetByDestinationAsync("London");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(hotels, result);
        }

        [Fact]
        public async Task GetByDestinationAsync_NoHotelsExist_ThrowsEntityNotFoundException()
        {
            // Arrange
            var hotels = new List<GetHotelResponse>();

            _mockHotelRepository.Setup(r => r.GetByDestinationAsync("London")).ReturnsAsync(hotels);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetByDestinationAsync("London"));
        }

        [Fact]
        public async Task CreateAsync_ValidRequest_ReturnsHotel()
        {
            // Arrange
            var request = new PostHotelRequest
            {
                Title = "Hotel A",
                Address = "123 London St.",
                City = "London",
                Distance = 3.2,
                StarRating = 5,
                GuestRating = 4.6f,
                ReviewCount = 1234,
                HasFreeCancellation = true,
                HasPayOnArrival = false
            };

            var hotelId = 1;

            _mockHotelRepository.Setup(r => r.AddAsync(It.IsAny<Hotel>()))
                .ReturnsAsync((Hotel h) =>
                {
                    h.HotelId = hotelId; 
                    return h;
                });

            // Act
            var result = await _service.CreateAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(hotelId, result.HotelId);
            Assert.Equal(request.Title, result.Title);
            Assert.Equal(request.Address, result.Address);
            Assert.Equal(request.City, result.City);
            Assert.Equal(request.Distance, result.Distance);
            Assert.Equal(request.StarRating, result.StarRating);
            Assert.Equal(request.GuestRating, result.GuestRating);
            Assert.Equal(request.ReviewCount, result.ReviewCount);
            Assert.Equal(request.HasFreeCancellation, result.HasFreeCancellation);
            Assert.Equal(request.HasPayOnArrival, result.HasPayOnArrival);
        }

        [Fact]
        public async Task DeleteByIdAsync_HotelExists_HotelDeleted()
        {
            // Arrange
            int hotelId = 1;

            _mockHotelRepository.Setup(r => r.DeleteByIdAsync(hotelId)).ReturnsAsync(10);

            // Act
            await _service.DeleteByIdAsync(hotelId);

            // Assert
            _mockHotelRepository.Verify(r => r.DeleteByIdAsync(hotelId), Times.Once(), "Should be invoked once");
        }

        [Fact]
        public async Task DeleteByIdAsync_HotelDoesntExists_ThrowsEntityNotFoundException()
        {
            // Arrange
            int hotelId = 1;

            _mockHotelRepository.Setup(r => r.DeleteByIdAsync(hotelId)).ReturnsAsync(0); // 0 affected rows

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.DeleteByIdAsync(hotelId));
        }
    }
}
