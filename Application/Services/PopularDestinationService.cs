using Application.Interfaces;
using Domain.Entities;
using Domain.Repository_Interfaces;


namespace Application.Services
{
    public class PopularDestinationService : IPopularDestinationService
    {
        private readonly IPopularDestinationRepository _popularDestinationRepository;

        public PopularDestinationService(IPopularDestinationRepository popularDestinationRepository)
        {
            _popularDestinationRepository = popularDestinationRepository;
        }
        public async Task<List<PopularDestination>> GetAllAsync()
        {
            var popularDestinations = await _popularDestinationRepository.GetAllAsync();


            return popularDestinations;
        }
    }
}
