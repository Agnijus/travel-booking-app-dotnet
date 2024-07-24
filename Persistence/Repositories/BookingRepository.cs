using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;


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
            var query = "SELECT * FROM Booking WHERE BookingId = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Booking>(query, new { id });

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
            var query = "DELETE FROM Booking WHERE BookingId = @id";

            using (var connection = _context.CreateConnection())
            {
                 return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
