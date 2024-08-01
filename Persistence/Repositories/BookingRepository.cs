using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Booking> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT BookingId, GuestAccountId, HotelReservationId, TotalPrice, TransactionStatusId");
            sb.AppendLine("FROM Booking");
            sb.AppendLine("WHERE BookingId = @id");

            var query = sb.ToString();
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<Booking>(
                new CommandDefinition(query, new { id }, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
        }

        public async Task<Booking> AddAsync(Booking booking, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Booking (GuestAccountId, HotelReservationId, TotalPrice, TransactionStatusId)");
            sb.AppendLine("VALUES (@GuestAccountId, @HotelReservationId, @TotalPrice, @TransactionStatusId);");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            var query = sb.ToString();
            var id = await _unitOfWork.Connection.QuerySingleAsync<int>(
                new CommandDefinition(query, booking, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
            booking.BookingId = id;
            return booking;
        }

        public async Task<int> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DELETE FROM Booking");
            sb.AppendLine("WHERE BookingId = @id");

            var query = sb.ToString();
            return await _unitOfWork.Connection.ExecuteAsync(
                new CommandDefinition(query, new { Id = id }, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
        }
    }
}
