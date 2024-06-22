using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;


namespace Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DapperContext _context;
        public BookingRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Booking> GetByIdAsync(int Id)
        {
            var query = "SELECT * FROM Booking WHERE id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Booking>(query, new { Id });

            }
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            var query = @"
            INSERT INTO Booking (GuestAccountId, HotelReservationId, TotalPrice, TransactionStatusId) 
            VALUES (@GuestAccountId, @HotelReservationId, @TotalPrice, @TransactionStatusId);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, booking);
                booking.BookingId = id;

                return booking;
            }
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "DELETE FROM Booking WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                 return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
