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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetHotelBookingById(int id)
        //{
        //    var hotelBookingDto = await _hotelBookingService.GetByIdAsync(id);

        //    return Ok(hotelBookingDto);
        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transactionDto = await _hotelBookingService.GetByIdAsync(id);

            return Ok(transactionDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuestAccountHotelTransaction([FromBody] GuestAccountHotelBookingDto guestAccountHotelBookingDto)
        {
            var transactionDto = await _hotelBookingService.CreateAsync(guestAccountHotelBookingDto);

            return CreatedAtAction(nameof(GetTransactionById), new { id = transactionDto.Id }, transactionDto);
        }

    }
}
