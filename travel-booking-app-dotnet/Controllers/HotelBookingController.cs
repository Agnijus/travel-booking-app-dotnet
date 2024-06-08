using Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetBookingById(int id)
        {
            var bookingDto = await _hotelBookingService.GetByIdAsync(id);

            return Ok(bookingDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] GuestAccountHotelBookingDto guestAccountHotelBookingDto)
        {
            var bookingDto = await _hotelBookingService.CreateAsync(guestAccountHotelBookingDto);

            return CreatedAtAction(nameof(GetBookingById), new { id = bookingDto.Id }, bookingDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookingById(int id)
        {
            await _hotelBookingService.DeleteByIdAsync(id);

            return NoContent();
        }

    }
}
