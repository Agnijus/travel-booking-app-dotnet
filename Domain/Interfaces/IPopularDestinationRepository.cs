using Domain.Entities;


namespace Domain.Repository_Interfaces
{
    public interface IPopularDestinationRepository
    {
        Task<List<PopularDestination>> GetAllAsync();
    }
}
