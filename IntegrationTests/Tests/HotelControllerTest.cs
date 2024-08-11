using Application.Models.Requests;
using Domain.Entities;
using IntegrationTests.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace IntegrationTests.Tests
{
    [Collection("Sequential")]

    public class HotelControllerTest : IClassFixture<TestFixture>
    {
        private readonly HotelHelper _hotelHelper;

        public HotelControllerTest(TestFixture fixture)
        {
            _hotelHelper = new HotelHelper(fixture);
        }

        [Fact]
        public async Task GET_GetsHotelById_Returns200()
        {
            // Act
            var apiResponse = await _hotelHelper.GetHotelById(1); 

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task GET_GetsHotelById_Returns404()
        {
            // Act
            var apiResponse = await _hotelHelper.GetHotelById(999); 

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.NotFound, actual: (int)apiResponse.StatusCode);
            Assert.False(apiResponse.IsSuccess);
            Assert.Null(apiResponse.Data);
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
        public async Task GET_GetsHotelByDestination_Returns200()
        {
            // Act
            var apiResponse = await _hotelHelper.GetByDestination("London");

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
            var hotels = JsonConvert.DeserializeObject<List<Hotel>>(apiResponse.Data.ToString());
            Assert.All(hotels, hotel => Assert.Equal("London", hotel.City));
        }

        [Fact]
        public async Task GET_CreatesHotel_Returns200()
        {
            // Arrange

            var request = new PostHotelRequest
            {
                Title = "Hotel A",
                Address = "123 London St.",
                City = "London",
                Distance = 3.2d,
                StarRating = 5,
                GuestRating = 4.6d,
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
    }
}
