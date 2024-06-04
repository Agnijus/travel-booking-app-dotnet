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
        Task<TransactionDto> GetByIdAsync(int id);
        Task DeleteAsync(TransactionDto transactionDto);

        Task<TransactionDto> CreateAsync(GuestAccountHotelBookingDto guestAccountHotelBookingDto);



    }
}
