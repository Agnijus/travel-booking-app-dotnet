using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Text;

namespace Persistence.Repositories
{
    public class GuestAccountRepository : IGuestAccountRepository
    {
        //private readonly IDapperContext _context;
        private readonly DbContextMembers _context;

        public GuestAccountRepository(DbContextMembers context)
        {
            _context = context;
        }
        public async Task<GuestAccount?> GetByIdAsync(int id)
        {
            var guestAccount = await (from g in _context.GuestAccounts.AsNoTracking()
                                      where g.GuestAccountId == id
                                      select g).FirstOrDefaultAsync();

            return guestAccount;     

            //var guestAccount = _context.GuestAccounts.FirstOrDefault(g => g.GuestAccountId == id);
            //await _context.SaveChangesAsync();
            //return guestAccount;





            //var sb = new StringBuilder();

            //sb.AppendLine("SELECT Id, FirstName, LastName, Email, ContactNumber");
            //sb.AppendLine("FROM GuestAccount");
            //sb.AppendLine("WHERE Id = @id");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    return await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QueryFirstOrDefaultAsync<GuestAccount>(query, new { id }));
            //}
        }

        public async Task<int> AddAsync(GuestAccount guestAccount)
        {
            _context.GuestAccounts.Add(guestAccount);
            await _context.SaveChangesAsync();

            return guestAccount.GuestAccountId;
            
            //var sb = new StringBuilder();

            //sb.AppendLine("INSERT INTO GuestAccount (FirstName, LastName, Email, ContactNumber)");
            //sb.AppendLine("VALUES (@FirstName, @LastName, @Email, @ContactNumber);");
            //sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    return await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QuerySingleAsync<int>(query, guestAccount));
            //}
        }

        public async Task DeleteByIdAsync(int id)
        {
            var guestAccount = await (from g in _context.GuestAccounts.AsNoTracking()
                                      where g.GuestAccountId == id
                                      select g).FirstOrDefaultAsync();



            //var guestAccount = await _context.GuestAccounts.FindAsync(id);

            if (guestAccount != null)
            {
                _context.GuestAccounts.Remove(guestAccount);
                await _context.SaveChangesAsync();
            }

            //var sb = new StringBuilder();

            //sb.AppendLine("DELETE FROM GuestAccount");
            //sb.AppendLine("WHERE Id = @Id");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.ExecuteAsync(query, new { id }));
            //}
        }
    }
}
