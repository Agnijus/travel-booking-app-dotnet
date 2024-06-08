using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace travel_booking_app_dotnet.Controllers
{
    [ApiController]
    [Route("/api/hotelSearch")]

    public class HotelSearchController : ControllerBase
    {
        private readonly IHotelSearchService _hotelSearchService;
        public HotelSearchController(IHotelSearchService hotelSearchService)
        {
            _hotelSearchService = hotelSearchService;
        }

        [HttpGet("{destination}")]
        public async Task<IActionResult> GetByDestination(string destination)
        {
            var hotelDto = await _hotelSearchService.GetByDestinationAsync(destination);

            return Ok(hotelDto);
        }

    }
}
