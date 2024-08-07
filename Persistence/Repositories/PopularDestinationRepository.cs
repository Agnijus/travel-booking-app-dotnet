using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;
using System.Text;

namespace Persistence.Repositories
{
    public class PopularDestinationRepository : IPopularDestinationRepository
    {
        private readonly IDapperContext _context;

        public PopularDestinationRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<PopularDestination>> GetAllAsync()
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT City, Location FROM PopularDestination");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                var destinations = await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
                    connection.QueryAsync<PopularDestination>(query));

                return destinations.ToList();
            }
        }
    }
}
