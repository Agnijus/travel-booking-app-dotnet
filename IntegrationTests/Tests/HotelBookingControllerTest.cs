
using Application.Models.Requests;
using Domain.Entities;
using IntegrationTests.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace IntegrationTests.Tests
{
    public class HotelBookingControllerTest : IClassFixture<TestFixture>
    {
        private readonly HotelBookingHelper _hotelBookingHelper;

        public HotelBookingControllerTest(TestFixture fixture)
        {
            _hotelBookingHelper = new HotelBookingHelper(fixture);
        }

        [Fact]
        public async Task POST_CreatesBooking_Returns200()
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

            // Act
            var apiResponse = await _hotelBookingHelper.CreateBooking(request);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task GET_GetsBookingById_Returns200()
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

            var createResponse = await _hotelBookingHelper.CreateBooking(request);
            var createdBooking = JsonConvert.DeserializeObject<Booking>(createResponse.Data.ToString());

            // Act
            var apiResponse = await _hotelBookingHelper.GetBookingById(createdBooking.BookingId);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task DELETE_DeletesBookingById_Returns200()
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

            var createResponse = await _hotelBookingHelper.CreateBooking(request);
            var createdBooking = JsonConvert.DeserializeObject<Booking>(createResponse.Data.ToString());

            // Act
            var apiResponse = await _hotelBookingHelper.DeleteBookingById(createdBooking.BookingId);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
        }
    }
}
