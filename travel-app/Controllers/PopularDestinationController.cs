using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using travel_app.Models;

namespace travel_app.Controllers
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
        public async Task<ApiResponse> GetAllAsync()
        {
            var popularDestinations = await _popularDestinationService.GetAllAsync();

            return new ApiResponse(string.Format(Constant.GetAllPopularDestinationSuccess), popularDestinations);
        }
    }
}
