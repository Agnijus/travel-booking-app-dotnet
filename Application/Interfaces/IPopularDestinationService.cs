using Domain.Entities;


namespace Application.Interfaces
{
    public interface IPopularDestinationService
    {
        Task<List<PopularDestination>> GetAllAsync();
    }
}
