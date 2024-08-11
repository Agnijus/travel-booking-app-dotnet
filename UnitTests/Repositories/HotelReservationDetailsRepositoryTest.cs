
using Dapper;
using Domain.Entities;
using Moq;
using Moq.Dapper;
using Persistence.Data;
using Persistence.Repositories;
using System.Data;

namespace UnitTests.Repositories
{
    public class HotelReservationDetailsRepositoryTest
    {
        private readonly Mock<DbContextMembers> _mockContext;
        private readonly Mock<IDbConnection> _mockDbConnection;
        private readonly HotelReservationDetailsRepository _repository;

        public HotelReservationDetailsRepositoryTest()
        {
            _mockContext = new Mock<DbContextMembers>();
            _mockDbConnection = new Mock<IDbConnection>();
            _mockContext.Setup(m => m.CreateConnection()).Returns(_mockDbConnection.Object);
            _repository = new HotelReservationDetailsRepository(_mockContext.Object);
        }

        [Fact]
        public async Task AddAsync_ReturnsNewlyCreatedId()
        {
            // Arrange
            var reservation = new HotelReservation
            {
                HotelId = 1,
                RoomTypeId = 2,
                CheckInDate = new DateTime(2024, 7, 1),
                CheckOutDate = new DateTime(2023, 7, 8),
                TotalPrice = 499.99d
            };

            _mockDbConnection.SetupDapperAsync(d => d.QuerySingleAsync<int>(
                It.IsAny<string>(), It.IsAny<HotelReservation>(), null, null, null))
                .ReturnsAsync(10);

            // Act
            var id = await _repository.AddAsync(reservation);

            // Assert
            Assert.Equal(10, id);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsNewlyCreatedId()
        {
            // Arrange
            var reservation = new HotelReservation
            {
                HotelId = 1,
                RoomTypeId = 2,
                CheckInDate = new DateTime(2024, 7, 1),
                CheckOutDate = new DateTime(2023, 7, 8),
                TotalPrice = 499.99d
            };

            _mockDbConnection.SetupDapperAsync(d => d.QuerySingleAsync<int>(
                It.IsAny<string>(), It.IsAny<HotelReservation>(), null, null, null))
                .ReturnsAsync(10);

            // Act
            var id = await _repository.AddAsync(reservation);

            // Assert
            Assert.Equal(10, id);
        }
    }
}
