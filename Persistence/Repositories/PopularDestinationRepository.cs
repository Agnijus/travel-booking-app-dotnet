using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Entities;

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
