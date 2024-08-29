using Application.Models.Requests;
using IntegrationTests.Helpers;
using System.Net;

namespace IntegrationTests.Tests
{
    [Collection("Sequential")]
    public class HotelBookingControllerTest : IClassFixture<TestFixture>
    {
        private readonly HotelBookingHelper _hotelBookingHelper;

        public HotelBookingControllerTest(TestFixture fixture)
        {
            _hotelBookingHelper = new HotelBookingHelper(fixture);
        }

        [Fact]
        public async Task GET_GetsBookingById_Returns200()
        {
            var apiResponse = await _hotelBookingHelper.GetBookingById(1);

            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task POST_CreatesBooking_Returns200()
        {
            // Arrange
            var request = new PostBookingRequest
            {
                FirstName = "Agnijus",
                LastName = "Botyrius",
                Email = "agnijus.botyrius@gmail.com",
                ContactNumber = "+123456789",
                HotelId = 1,
                RoomTypeId = 1,
                CheckInDate = new DateTime(2024, 1, 1),
                CheckOutDate = new DateTime(2025, 1, 1),
                TotalPrice = 1250
            };

            // Act
            var apiResponse = await _hotelBookingHelper.CreateBooking(request);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }
    }
}
