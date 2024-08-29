using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Text;

namespace Persistence.Repositories
{
    public class HotelReservationDetailsRepository : IHotelReservationDetailsRepository
    {
        private readonly DbContextMembers _context;

        public HotelReservationDetailsRepository(DbContextMembers context)
        {
            _context = context;
        }

        public async Task<HotelReservation?> GetByIdAsync(int Id)
        {
            return await (from hr in _context.HotelReservations.AsNoTracking()
                                          where hr.HotelReservationId == Id
                                          select hr).FirstOrDefaultAsync();
        }

        public async Task<int> AddAsync(HotelReservation hotelReservation)
        {
            await _context.HotelReservations.AddAsync(hotelReservation);
            await _context.SaveChangesAsync();
            return hotelReservation.HotelReservationId;

        }
    }
}
