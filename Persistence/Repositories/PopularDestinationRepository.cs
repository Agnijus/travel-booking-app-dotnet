using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;


namespace Persistence.Repositories
{
    public class PopularDestinationRepository : IPopularDestinationRepository
    {
        private readonly DapperContext _context;
        public PopularDestinationRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<PopularDestination>> GetAllAsync()
        {
             var query = "SELECT * FROM PopularDestination";

             using (var connection = _context.CreateConnection())
                {
                var destinations = await connection.QueryAsync<PopularDestination>(query);

                return destinations.ToList();  
             }    
        }
    }
}
