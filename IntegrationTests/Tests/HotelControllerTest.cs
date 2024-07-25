using IntegrationTests.Helpers;
using Newtonsoft.Json;
using travel_app.Models;

namespace IntegrationTests.Tests
{
    public class HotelControllerTest : TestCore
    {
        private readonly HotelHelper _hotelHelper;

        public HotelControllerTest(TestFixture fixture) : base(fixture)
        {
            _hotelHelper = new HotelHelper(fixture);
        }


        [Fact]
        public async Task GetHotels_ReturnsHotels()
        {
            var response = await _hotelHelper.GetHotels();
            var responseString = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseString);

            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }
    }
}
