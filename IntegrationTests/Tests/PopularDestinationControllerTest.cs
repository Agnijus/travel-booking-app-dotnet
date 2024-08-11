using IntegrationTests.Helpers;
using System.Net;

namespace IntegrationTests.Tests
{
    public class PopularDestinationControllerTest : IClassFixture<TestFixture>
    {
        private readonly PopularDestinationHelper _popularDestinationHelper;

        public PopularDestinationControllerTest(TestFixture fixture)
        {
            _popularDestinationHelper = new PopularDestinationHelper(fixture);
        }


        [Fact]
        public async Task GET_ReturnsAllPopularDestinations_Returns404()
        {
            // Act
            var apiResponse = await _popularDestinationHelper.GetAllPopularDestinations();

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.NotFound, actual: (int)apiResponse.StatusCode);
            Assert.False(apiResponse.IsSuccess);
            Assert.Null(apiResponse.Data);
        }
    }
}
