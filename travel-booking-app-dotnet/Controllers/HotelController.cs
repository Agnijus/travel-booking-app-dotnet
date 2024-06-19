using Contracts.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotelDto = await _hotelService.GetByIdAsync(id);

            return Ok(hotelDto);
        }

        [HttpGet("destination/{destination}")]
        public async Task<IActionResult> GetByDestination(string destination)
        {
            var hotelDto = await _hotelService.GetByDestinationAsync(destination);

            return Ok(hotelDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] PostHotelRequest request)
        {
            var hotel = await _hotelService.CreateAsync(request);

            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.Id }, hotel);
        }
    }
}
