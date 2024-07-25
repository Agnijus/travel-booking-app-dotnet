using System.Text;
using System.Text.Json;
using Application.Models.Requests;

namespace IntegrationTests.Helpers
{
    public class HotelHelper : TestCore
    {
        public HotelHelper(TestFixture fixture) : base(fixture)
        {
        }

        public async Task<HttpResponseMessage> CreateHotel(PostHotelRequest request)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            return await Client.PostAsync("/api/hotels", jsonContent);
        }

        public async Task<HttpResponseMessage> GetHotelById(int id)
        {
            return await Client.GetAsync($"/api/hotels/{id}");
        }

        public async Task<HttpResponseMessage> GetHotels()
        {
            return await Client.GetAsync("/api/hotels");
        }

        public async Task<HttpResponseMessage> GetByDestination(string destination)
        {
            return await Client.GetAsync($"/api/hotels/destination/{destination}");
        }
    }
}
