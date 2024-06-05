using Contracts.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstractions;


namespace travel_booking_app_dotnet.Controllers
{
    [ApiController]
    [Route("/api/booking")]
    public class BookingTransactionController : ControllerBase
    {
        private readonly IHotelBookingService _hotelBookingService;
        public BookingTransactionController(IHotelBookingService hotelBookingService)
        {
            _hotelBookingService = hotelBookingService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transactionDto = await _hotelBookingService.GetByIdAsync(id);

            return Ok(transactionDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] GuestAccountHotelBookingDto guestAccountHotelBookingDto)
        {
            var transactionDto = await _hotelBookingService.CreateAsync(guestAccountHotelBookingDto);

            return CreatedAtAction(nameof(GetTransactionById), new { id = transactionDto.Id }, transactionDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTransactionById(int id)
        {
            await _hotelBookingService.DeleteByIdAsync(id);

            return NoContent();
        }

    }
}
