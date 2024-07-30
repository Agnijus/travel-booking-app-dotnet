using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;
using System.Text;


namespace Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDapperContext _context;
        public BookingRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT BookingId, GuestAccountId, HotelReservationId, TotalPrice, TransactionStatusId");
            sb.AppendLine("FROM Booking");
            sb.AppendLine("WHERE BookingId = @id");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Booking>(query, new { id });

            }
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO Booking (GuestAccountId, HotelReservationId, TotalPrice, TransactionStatusId)");
            sb.AppendLine("VALUES (@GuestAccountId, @HotelReservationId, @TotalPrice, @TransactionStatusId);");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, booking);
                booking.BookingId = id;

                return booking;
            }
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var sb = new StringBuilder();

            sb.AppendLine("DELETE FROM Booking");
            sb.AppendLine("WHERE BookingId = @id");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                 return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
