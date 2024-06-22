using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpGet]
        //public async Task<IActionResult> GetHotels()
        //{
        //    var hotels = await _hotelService.GetAllAsync();

        //    return Ok(hotels);
        //}

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetByIdAsync(id);

            return Ok(hotel);
        }

        //[HttpGet("destination/{destination}")]
        //public async Task<IActionResult> GetByDestination(string destination)
        //{
        //    var hotel = await _hotelService.GetByDestinationAsync(destination);

        //    return Ok(hotel);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] PostHotelRequest request)
        {
            var hotel = await _hotelService.CreateAsync(request);

            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HotelId }, hotel);
        }
    }
}
