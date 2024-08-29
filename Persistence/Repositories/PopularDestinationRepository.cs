using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Text;

namespace Persistence.Repositories
{
    public class PopularDestinationRepository : IPopularDestinationRepository
    {
        private readonly DbContextMembers _context;

        public PopularDestinationRepository(DbContextMembers context)
        {
            _context = context;
        }

        public async Task<List<PopularDestination>> GetAllAsync()
        {
            return await (from pd in _context.PopularDestinations.AsNoTracking()
                                            select pd).ToListAsync(); 
        }
    }
}
