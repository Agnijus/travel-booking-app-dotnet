using System.Text;
using Application.Models.Requests;
using travel_app.Models;
using Newtonsoft.Json;

namespace IntegrationTests.Helpers
{
    public class HotelHelper : TestCore
    {
        public HotelHelper(TestFixture fixture) : base(fixture)
        {
        }

        public async Task<ApiResponse> CreateHotel(PostHotelRequest request)
        {
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/api/hotels", jsonContent);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);
        }

        public async Task<ApiResponse> GetHotelById(int id)
        {
            var response = await Client.GetAsync($"/api/hotels/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);
        }

        public async Task<ApiResponse> GetHotels()
        {
            var response = await Client.GetAsync("/api/hotels");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);
        }

        public async Task<ApiResponse> GetByDestination(string destination)
        {
            var response = await Client.GetAsync($"/api/hotels/destination/{destination}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);
        }
    }
}
