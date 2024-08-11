using System.Text;
using travel_app.Models;
using Newtonsoft.Json;

namespace IntegrationTests.Helpers
{
    public class PopularDestinationHelper : TestCore
    {
        public PopularDestinationHelper(TestFixture fixture) : base(fixture)
        {
        }

        public async Task<ApiResponse?> GetAllPopularDestinations()
        {
            var response = await Client.GetAsync("/api/popularDestinations");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);
        }
    }
}
