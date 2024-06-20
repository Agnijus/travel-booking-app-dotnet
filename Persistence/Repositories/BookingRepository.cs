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
            var query = "SELECT * FROM Bookings WHERE id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Booking>(query, new { Id });

            }
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            var query = @"
            INSERT INTO Bookings (AccountId, ReservationId, TotalPrice, Status) 
            VALUES (@AccountId, @ReservationId, @TotalPrice, @Status);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    AccountId = booking.AccountId,
                    ReservationId = booking.ReservationId,
                    TotalPrice = booking.TotalPrice,
                    Status = booking.Status.ToString() 
                };

                var id = await connection.QuerySingleAsync<int>(query, parameters);
                booking.Id = id;

                var selectQuery = "SELECT * FROM Bookings WHERE Id = @Id";
                var createdBooking = await connection.QuerySingleAsync<Booking>(selectQuery, new { Id = id });
                return createdBooking;
            }
        }

        public async Task DeleteAsync(Booking booking)
        {
            var query = "DELETE FROM Bookings WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = booking.Id });
            }
        }
    }
}
