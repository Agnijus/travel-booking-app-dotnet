using System.Text;
using Application.Models.Requests;
using travel_app.Models;
using Newtonsoft.Json;

namespace IntegrationTests.Helpers
{
    public class HotelBookingHelper : TestCore
    {
        public HotelBookingHelper(TestFixture fixture) : base(fixture)
        {
        }

        public async Task<ApiResponse> CreateBooking(PostBookingRequest request)
        {
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/api/booking", jsonContent);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);
        }

        public async Task<ApiResponse> GetBookingById(int id)
        {
            var response = await Client.GetAsync($"/api/booking/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);
        }

        public async Task<ApiResponse> DeleteBookingById(int id)
        {
            var response = await Client.DeleteAsync($"/api/booking/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);
        }
    }
}
