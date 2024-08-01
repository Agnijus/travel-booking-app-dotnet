using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GuestAccountRepository : IGuestAccountRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestAccountRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GuestAccount> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT Id, FirstName, LastName, Email, ContactNumber");
            sb.AppendLine("FROM GuestAccount");
            sb.AppendLine("WHERE Id = @id");

            var query = sb.ToString();
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<GuestAccount>(
                new CommandDefinition(query, new { id }, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
        }

        public async Task<int> AddAsync(GuestAccount guestAccount, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO GuestAccount (FirstName, LastName, Email, ContactNumber)");
            sb.AppendLine("VALUES (@FirstName, @LastName, @Email, @ContactNumber);");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            var query = sb.ToString();
            return await _unitOfWork.Connection.QuerySingleAsync<int>(
                new CommandDefinition(query, guestAccount, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DELETE FROM GuestAccount");
            sb.AppendLine("WHERE Id = @Id");

            var query = sb.ToString();
            await _unitOfWork.Connection.ExecuteAsync(
                new CommandDefinition(query, new { id }, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
        }
    }
}
