using Application.Models.Requests;
using IntegrationTests.Helpers;
using Newtonsoft.Json;
using System.Net;
using travel_app.Core.Entities;

namespace IntegrationTests.Tests
{
    public class HotelControllerTest : IClassFixture<TestFixture>
    {
        private readonly HotelHelper _hotelHelper;

        public HotelControllerTest(TestFixture fixture)
        {
            _hotelHelper = new HotelHelper(fixture);
        }


        [Fact]
        public async Task GET_ReturnsAllHotels_Returns200()
        {
            // Act
            var apiResponse = await _hotelHelper.GetHotels();

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task POST_CreatesHotel_Returns200()
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

            // Act
            var apiResponse = await _hotelHelper.CreateHotel(request);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task GET_GetsHotelById_Returns200()
        {
            // Arrange
            var request = new PostHotelRequest
            {
                Title = "Hotel B",
                Address = "456 Another St",
                City = "London",
                Distance = 3.2,
                StarRating = 5,
                GuestRating = 4.7f,
                ReviewCount = 200,
                HasFreeCancellation = false,
                HasPayOnArrival = true
            };

            var createResponse = await _hotelHelper.CreateHotel(request);
            var createdHotel = JsonConvert.DeserializeObject<Hotel>(createResponse.Data.ToString());

            // Act
            var apiResponse = await _hotelHelper.GetHotelById(createdHotel.HotelId);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task GET_GetsHotelByDestination_Returns200()
        {
            // Arrange
            var request = new PostHotelRequest
            {
                Title = "Hotel C",
                Address = "789 Another St",
                City = "London",
                Distance = 2.5,
                StarRating = 4,
                GuestRating = 4.2f,
                ReviewCount = 150,
                HasFreeCancellation = true,
                HasPayOnArrival = false
            };

            await _hotelHelper.CreateHotel(request);

            // Act
            var apiResponse = await _hotelHelper.GetByDestination("London");

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);

            var hotels = JsonConvert.DeserializeObject<List<Hotel>>(apiResponse.Data.ToString());
            Assert.All(hotels, hotel => Assert.Equal("London", hotel.City));
        }
    }
}
