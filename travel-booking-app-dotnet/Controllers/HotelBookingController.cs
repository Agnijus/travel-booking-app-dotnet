using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


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
            var booking =  _hotelBookingService.GetByIdAsync(id);

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] PostBookingRequest request)
        {
            var booking = _hotelBookingService.CreateAsync(request);

            return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookingById(int id)
        {
            _hotelBookingService.DeleteByIdAsync(id);

            return NoContent();
        }

    }
}
