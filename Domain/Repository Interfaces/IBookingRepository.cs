using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository_Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetByIdAsync(int Id);

        void Insert(Booking booking);
        void Remove(Booking booking);
    }
}
