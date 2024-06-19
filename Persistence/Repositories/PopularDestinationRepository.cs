using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;


namespace Persistence.Repositories
{
    public class PopularDestinationRepository : IPopularDestinationRepository
    {
        public Task<List<PopularDestination>> GetAllAsync()
        {
            return Task.FromResult(PopularDestinationData.PopularDestinations);
        }
    }
}
