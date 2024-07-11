using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllAsync()
        {
            var popularDestinations = await _popularDestinationService.GetAllAsync();

            return Ok(new { StatusCode = 200, Message = "GET all popular destinations successful", popularDestinations });
        }
    }
}
