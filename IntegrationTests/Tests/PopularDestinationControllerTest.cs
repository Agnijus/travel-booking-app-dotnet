using IntegrationTests.Helpers;
using System.Net;

namespace IntegrationTests.Tests
{
    [Collection("Sequential")]

    public class PopularDestinationControllerTest : IClassFixture<TestFixture>
    {
        private readonly PopularDestinationHelper _popularDestinationHelper;

        public PopularDestinationControllerTest(TestFixture fixture)
        {
            _popularDestinationHelper = new PopularDestinationHelper(fixture);
        

        }

        [Fact]
        public async Task GET_ReturnsAllPopularDestinations_Returns200()
        {
            // Act
            var apiResponse = await _popularDestinationHelper.GetAllPopularDestinations();

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }
    }
}
