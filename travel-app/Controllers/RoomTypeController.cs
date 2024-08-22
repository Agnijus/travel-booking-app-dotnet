using Application.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using travel_app.Models;

namespace travel_app.Controllers
{
    [ApiController]
    [Route("/api/roomtype")]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRespository _repository;

        public RoomTypeController(IRoomTypeRespository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse> GetRoomTypeById(int id)
        {
            var response = await _repository.GetByIdAsync(id);
            
            return new ApiResponse(string.Format(Constant.GetRoomTypeByIdSuccess), response);
           
        }
    }
}
