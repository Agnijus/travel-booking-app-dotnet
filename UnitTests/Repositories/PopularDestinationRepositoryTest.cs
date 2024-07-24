using Dapper;
using Domain.Entities;
using Moq;
using Moq.Dapper;
using Persistence.Data;
using Persistence.Repositories;
using System.Data;
using Xunit;

namespace UnitTests.Repositories
{
    public class PopularDestinationRepositoryTest
    {
        private readonly Mock<IDapperContext> _mockContext;
        private readonly Mock<IDbConnection> _mockDbConnection;
        private readonly PopularDestinationRepository _repository;

        public PopularDestinationRepositoryTest()
        {
            _mockContext = new Mock<IDapperContext>();
            _mockDbConnection = new Mock<IDbConnection>();
            _mockContext.Setup(m => m.CreateConnection()).Returns(_mockDbConnection.Object);
            _repository = new PopularDestinationRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllDestinationsAsync_ReturnsAllDestinations()
        {
            // Arrange
            var destinations = new List<PopularDestination>
            {
                new PopularDestination { City = "London", Location = "Covent Garden" },
                new PopularDestination { City = "Las Vegas", Location = "Paradise" }
            };

            _mockDbConnection.SetupDapperAsync(c => c.QueryAsync<PopularDestination>(
                It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(destinations);

            // Act
            var results = await _repository.GetAllAsync();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(destinations.Count, results.Count);

            foreach (var destination in destinations)
            {
                Assert.Contains(results, r => r.City == destination.City && r.Location == destination.Location);
            }
        }

        [Fact]
        public async Task GetAllDestinationsAsync_ReturnsNoDestinations()
        {
            // Arrange
            var destinations = new List<PopularDestination>();

            _mockDbConnection.SetupDapperAsync(c => c.QueryAsync<PopularDestination>(
                It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(destinations);

            // Act
            var results = await _repository.GetAllAsync();

            // Assert
            Assert.Empty(results);
        }
    }
}
