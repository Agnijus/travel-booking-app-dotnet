using IntegrationTests.Helpers;
using System.Net;

namespace IntegrationTests.Tests
{
    [Collection("Sequential")]
    public class RoomTypeControllerTest : IClassFixture<TestFixture>
    {
        private readonly RoomTypeHelper _roomTypeHelper;


        public RoomTypeControllerTest(TestFixture fixture)
        {
            _roomTypeHelper = new RoomTypeHelper(fixture);
       

        }

        [Fact]
        public async Task GET_ReturnsRoomTypeById_Returns200()
        {
            // Act
            var apiResponse = await _roomTypeHelper.GetRoomTypeById(1); 

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task GET_ReturnsRoomTypeById_Returns404()
        {
            // Act
            var apiResponse = await _roomTypeHelper.GetRoomTypeById(999); 

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.NotFound, actual: (int)apiResponse.StatusCode);
            Assert.False(apiResponse.IsSuccess);
            Assert.Null(apiResponse.Data);
        }
    }
}
