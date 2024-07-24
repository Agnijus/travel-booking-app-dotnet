using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repository_Interfaces;
using Moq;

namespace UnitTests.Services
{
    public class PopularDestinationServiceTest
    {
        private readonly Mock<IPopularDestinationRepository> _mockPopularDestinationRepository;
        private readonly PopularDestinationService _service;

        public PopularDestinationServiceTest()
        {
            _mockPopularDestinationRepository = new Mock<IPopularDestinationRepository>();
            _service = new PopularDestinationService(_mockPopularDestinationRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_PopularDestinationsExist_ReturnsPopularDestinations()
        {
            // Arrange
            var destinations = new List<PopularDestination>
            {
                new PopularDestination { City = "London", Location = "Covent Garden" },
                new PopularDestination { City = "Las Vegas", Location = "Paradise" }
            };

            _mockPopularDestinationRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(destinations);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(destinations, result);
        }

        [Fact]
        public async Task GetAllAsync_NoPopularDestinationsExist_ThrowsEntityNotFoundException()
        {
            // Arrange
            var destinations = new List<PopularDestination>();

            _mockPopularDestinationRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(destinations);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetAllAsync());
        }
    }
}
