using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstractions;

namespace travel_booking_app_dotnet.Controllers
{
    [ApiController]
    [Route("/api/popularDestinations")]
    public class PopularDestinationController : ControllerBase
    {
        private readonly IPopularDestinationService _popularDestinationService;

        public PopularDestinationController(IPopularDestinationService popularDestinationService)
        {
            _popularDestinationService = popularDestinationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var popularDestinations = await _popularDestinationService.GetAllAsync();

            return Ok(popularDestinations);
        }
    }
}
