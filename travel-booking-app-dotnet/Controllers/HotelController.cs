using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace travel_booking_app_dotnet.Controllers
{
    [ApiController]
    [Route("/api/hotels")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _hotelService.GetAllAsync();

            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(uint id)
        {
            var hotelDto = await _hotelService.GetByIdAsync(id);

            return Ok(hotelDto);
        }

        
    }
}
