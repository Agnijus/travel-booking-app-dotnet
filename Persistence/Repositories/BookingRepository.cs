using Domain.Entities;
using Domain.Models.Responses;
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

        public async Task<GetBookingResponse?> GetByIdAsync(int id)
        {
            return await (from b in _context.Bookings
                                         join ga in _context.GuestAccounts on b.GuestAccountId equals ga.GuestAccountId
                                         join hr in _context.HotelReservations on b.HotelReservationId equals hr.HotelReservationId
                                         join h in _context.Hotels on hr.HotelId equals h.HotelId
                                         join ts in _context.TransactionStatuses on b.TransactionStatusId equals ts.TransactionStatusId
                                         where b.BookingId == id
                                         select new GetBookingResponse
                                         {
                                             BookingId = b.BookingId,
                                             FullName = ga.FirstName + " " + ga.LastName,
                                             HotelTitle = h.Title,
                                             CheckInDate = hr.CheckInDate,
                                             CheckOutDate = hr.CheckOutDate,
                                             TotalPrice = (int)hr.TotalPrice,
                                             TransactionStatus = ts.Description
                                         }).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<PostBookingResponse> AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return new PostBookingResponse { BookingId = booking.BookingId };
        }
    }
}
