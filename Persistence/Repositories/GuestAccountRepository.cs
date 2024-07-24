using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class GuestAccountRepository : IGuestAccountRepository
    {
        private readonly IDapperContext _context;

        public GuestAccountRepository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<GuestAccount> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM GuestAccount WHERE id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GuestAccount>(query, new { id });
            }
        }

        public async Task<int> AddAsync(GuestAccount guestAccount)
        {
            var query = @"
            INSERT INTO GuestAccount (FirstName, LastName, Email, ContactNumber) 
            VALUES (@FirstName, @LastName, @Email, @ContactNumber);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, guestAccount);
                return id;
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var query = "DELETE FROM GuestAccount WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
