using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class GuestAccountRepository : IGuestAccountRepository
    {
        private readonly DbContextMembers _context;

        public GuestAccountRepository(DbContextMembers context)
        {
            _context = context;
        }
        public async Task<GuestAccount?> GetByIdAsync(int id)
        {
            return await (from g in _context.GuestAccounts.AsNoTracking()
                                      where g.GuestAccountId == id
                                      select g).FirstOrDefaultAsync();
        }

        public async Task<int> AddAsync(GuestAccount guestAccount)
        {
            _context.GuestAccounts.Add(guestAccount);
            await _context.SaveChangesAsync();

            return guestAccount.GuestAccountId;
        }
    }
}
