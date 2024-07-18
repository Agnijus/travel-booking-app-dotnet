using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using travel_app.Models;

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
        public async Task<ApiResponse> GetBookingById(int id)
        {
            var booking = await _hotelBookingService.GetByIdAsync(id);

            return new ApiResponse("GET booking by id successful", booking);
        }

        [HttpPost]
        public async Task<ApiResponse> CreateBooking([FromBody] PostBookingRequest request)
        {
            var booking = await _hotelBookingService.CreateAsync(request);

            return new ApiResponse("Booking POST request successful", booking);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> DeleteBookingById(int id)
        {
            await _hotelBookingService.DeleteByIdAsync(id);

            return new ApiResponse("DELETE booking by id successful", null);
        }
    }
}
