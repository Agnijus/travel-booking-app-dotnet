using Contracts.DTOs;
using Domain.Repository_Interfaces;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Entities;

namespace Services
{
    public class PopularDestinationService : IPopularDestinationService
    {
        private readonly IPopularDestinationRepository _popularDestinationRepository;

        public PopularDestinationService(IPopularDestinationRepository popularDestinationRepository)
        {
            _popularDestinationRepository = popularDestinationRepository;
        }
        public async Task<List<PopularDestinationDto>> GetAllAsync()
        {
            var popularDestinations = await _popularDestinationRepository.GetAllAsync();

            var popularDestinationsDto = popularDestinations.Adapt<List<PopularDestinationDto>>();

            return popularDestinationsDto;
        }
    }
}
