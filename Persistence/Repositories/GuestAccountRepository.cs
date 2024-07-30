using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;
using System.Text;

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
            var sb = new StringBuilder();

            sb.AppendLine("SELECT Id, FirstName, LastName, Email, ContactNumber");
            sb.AppendLine("FROM GuestAccount");
            sb.AppendLine("WHERE Id = @id");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GuestAccount>(query, new { id });
            }
        }

        public async Task<int> AddAsync(GuestAccount guestAccount)
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO GuestAccount (FirstName, LastName, Email, ContactNumber)");
            sb.AppendLine("VALUES (@FirstName, @LastName, @Email, @ContactNumber);");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, guestAccount);
                return id;
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var sb = new StringBuilder();

            sb.AppendLine("DELETE FROM GuestAccount");
            sb.AppendLine("WHERE Id = @Id");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
