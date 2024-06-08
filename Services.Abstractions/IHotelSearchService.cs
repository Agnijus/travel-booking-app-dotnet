using Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IHotelSearchService
    {
        Task<List<HotelDto>> GetByDestinationAsync(string destination);
    }
}
