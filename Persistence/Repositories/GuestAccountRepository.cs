using Azure.Core;
using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class GuestAccountRepository : IGuestAccountRepository
    {
        private readonly DapperContext _context;

        public GuestAccountRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<GuestAccount> GetByIdAsync(int Id)
        {
            var query = "SELECT * FROM GuestAccounts WHERE id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GuestAccount>(query, new { Id });
            }
        }

        public async Task<int> AddAsync(GuestAccount guestAccount)
        {
            var query = @"
            INSERT INTO GuestAccounts (FirstName, LastName, Email, ContactNumber) 
            VALUES (@FirstName, @LastName, @Email, @ContactNumber);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, guestAccount);
                return id;
            }
        }

        public async Task DeleteAsync(GuestAccount guestAccount)
        {
            var query = "DELETE FROM GuestAccounts WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = guestAccount.Id });
            }
        }
    }
}
