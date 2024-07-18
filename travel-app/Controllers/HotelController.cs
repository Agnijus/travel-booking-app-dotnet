using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using travel_app.Models;

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
        public async Task<ApiResponse> GetHotels()
        {
            var hotels = await _hotelService.GetAllAsync();
            return new ApiResponse(string.Format(Constant.GetAllHotelsSuccess), hotels);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResponse> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetByIdAsync(id);
            return new ApiResponse(string.Format(Constant.GetHotelByIdSuccess), hotel);
        }

        [HttpGet("destination/{destination}")]
        public async Task<ApiResponse> GetByDestination(string destination)
        {
            var hotels = await _hotelService.GetByDestinationAsync(destination);
            return new ApiResponse(string.Format(Constant.GetHotelByDestinationSuccess), hotels);
        }

        [HttpPost]
        public async Task<ApiResponse> CreateHotel([FromBody] PostHotelRequest request)
        {
            var hotel = await _hotelService.CreateAsync(request);
            return new ApiResponse(string.Format(Constant.PostHotelSuccess), hotel);
        }
    }
}
