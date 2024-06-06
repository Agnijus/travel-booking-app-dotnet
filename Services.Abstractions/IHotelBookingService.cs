using Contracts.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services.Abstractions
{
    public interface IHotelBookingService
    {
        Task<BookingDto> GetByIdAsync(int id);
        Task DeleteByIdAsync(int  id);

        Task<BookingDto> CreateAsync(GuestAccountHotelBookingDto guestAccountHotelBookingDto);

    }
}
