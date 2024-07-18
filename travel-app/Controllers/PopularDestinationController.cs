using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using travel_app.Core.Entities;
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

            return new ApiResponse("GET all popular destinations successful", popularDestinations);
        }
    }
}
