using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using travel_app.Core.Entities;

namespace travel_app.Controllers
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

            return Ok(new { StatusCode = 200, Message = "GET all hotels successful", hotels });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetByIdAsync(id);

            return Ok(new { StatusCode = 200, Message = "GET hotels by id successful", hotel });
        }

        [HttpGet("destination/{destination}")]
        public async Task<IActionResult> GetByDestination(string destination)
        {
            var hotels = await _hotelService.GetByDestinationAsync(destination);

            return Ok(new { StatusCode = 200, Message = "GET hotels by destination successful", hotels });
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] PostHotelRequest request)
        {
            var hotel = await _hotelService.CreateAsync(request);

            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HotelId }, hotel);
        }
    }
}
