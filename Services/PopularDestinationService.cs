using Domain.Repository_Interfaces;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PopularDestinationService : IPopularDestinationService
    {
        private readonly IPopularDestinationRepository _popularDestinationRepository;

        public PopularDestinationService(IPopularDestinationRepository popularDestinationRepository)
        {
            _popularDestinationRepository = popularDestinationRepository;
        }
        public async Task<List<string>> GetAllAsync()
        {
            var popularDestinations = await _popularDestinationRepository.GetAllAsync();

            return popularDestinations;
        }
    }
}
