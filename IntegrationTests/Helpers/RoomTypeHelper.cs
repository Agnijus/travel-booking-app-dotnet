using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using travel_app.Models;

namespace IntegrationTests.Helpers
{
    public class RoomTypeHelper : TestCore
    {
        public RoomTypeHelper(TestFixture fixture) : base(fixture)
        {
        }

        public async Task<ApiResponse?> GetRoomTypeById(int id)
        {
            var response = await Client.GetAsync($"/api/roomtype/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(responseString);

        }
    }
}
