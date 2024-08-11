using Domain.Entities;
using Domain.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;


namespace Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbContextMembers _context;
        public BookingRepository(DbContextMembers context)
        {
            _context = context;
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            var booking = await (from b in _context.Bookings.AsNoTracking()
                                 where b.BookingId == id
                                 select b).FirstOrDefaultAsync();


            return booking;

            //var sb = new StringBuilder();

            //sb.AppendLine("SELECT BookingId, GuestAccountId, HotelReservationId, TotalPrice, TransactionStatusId");
            //sb.AppendLine("FROM Booking");
            //sb.AppendLine("WHERE BookingId = @id");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    return await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QueryFirstOrDefaultAsync<Booking>(query, new { id }));
            //}
        }

        public async Task<Booking> AddAsync(Booking booking)
        {

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;

            //var sb = new StringBuilder();

            //sb.AppendLine("INSERT INTO Booking (GuestAccountId, HotelReservationId, TotalPrice, TransactionStatusId)");
            //sb.AppendLine("VALUES (@GuestAccountId, @HotelReservationId, @TotalPrice, @TransactionStatusId);");
            //sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            //var query = sb.ToString();



            //using (var connection = _context.CreateConnection())
            //{
            //    var id = await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QuerySingleAsync<int>(query, booking));
            //    booking.BookingId = id;
            //    return booking;
            //}
        }

        public async Task<int?> DeleteByIdAsync(int id)
        {
            var booking = await (from b in _context.Bookings.AsNoTracking()
                                 where b.BookingId == id
                                 select b).FirstOrDefaultAsync();

            if (booking == null)
            {
                return null;
            }

            _context.Bookings.Remove(booking);
            return await _context.SaveChangesAsync();

            //var sb = new StringBuilder();

            //sb.AppendLine("DELETE FROM Booking");
            //sb.AppendLine("WHERE BookingId = @id");

            //var query = sb.ToString();
            //using (var connection = _context.CreateConnection())
            //{
            //    return await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.ExecuteAsync(query, new { Id = id }));
            //}
        }
    }
}
