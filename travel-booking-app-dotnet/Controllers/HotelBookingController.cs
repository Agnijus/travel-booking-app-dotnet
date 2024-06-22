using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;


namespace travel_app.Controllers
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
            var booking = await _hotelBookingService.GetByIdAsync(id);

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] PostBookingRequest request)
        {
            var booking = await _hotelBookingService.CreateAsync(request);

            return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookingById(int id)
        {
            await _hotelBookingService.DeleteByIdAsync(id);

            return NoContent();
        }

    }
}
