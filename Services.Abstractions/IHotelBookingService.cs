using Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IHotelBookingService
    {
        Task<HotelDto> GetByIdAsync(int id);
        Task<HotelBookingDto> CreateAsync(HotelBookingForCreationDto hotelBookingForCreationDto);
        Task DeleteAsync(HotelBookingDto hotelBookingDto);
    }
}
