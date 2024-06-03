using Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstractions;


namespace travel_booking_app_dotnet.Controllers
{
    [ApiController]
    [Route("/api/booking")]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingService _hotelBookingService;
        public HotelBookingController(IHotelBookingService hotelBookingService)
        {
            _hotelBookingService = hotelBookingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelBookingById(int id)
        {
            var hotelBookingDto = await _hotelBookingService.GetByIdAsync(id);

            return Ok(hotelBookingDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelBooking([FromBody] HotelBookingForCreationDto hotelBookingForCreationDto)
        {
            var hotelBookingDto = await _hotelBookingService.CreateAsync(hotelBookingForCreationDto);
            return CreatedAtAction(nameof(GetHotelBookingById), new { id = hotelBookingDto.Id }, hotelBookingDto);
        }

    }
}
