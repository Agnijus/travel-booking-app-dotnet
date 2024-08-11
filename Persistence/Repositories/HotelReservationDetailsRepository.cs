using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Text;

namespace Persistence.Repositories
{
    public class HotelReservationDetailsRepository : IHotelReservationDetailsRepository
    {
        //private readonly IDapperContext _context;
        private readonly DbContextMembers _context;

        public HotelReservationDetailsRepository(DbContextMembers context)
        {
            _context = context;
        }

        public async Task<HotelReservation?> GetByIdAsync(int Id)
        {
            var hotelReservation = await (from hr in _context.HotelReservations.AsNoTracking()
                                          where hr.HotelReservationId == Id
                                          select hr).FirstOrDefaultAsync();

            return hotelReservation;


            //var hotelReservation = await _context.HotelReservations.FindAsync(Id);
            //await _context.SaveChangesAsync();
            //return hotelReservation;



            //var sb = new StringBuilder();

            //sb.AppendLine("SELECT r.HotelId, r.RoomTypeId, r.CheckInDate, r.CheckOutDate, r.TotalPrice");
            //sb.AppendLine("FROM HotelReservation r");
            //sb.AppendLine("WHERE r.Id = @id");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    return await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QueryFirstOrDefaultAsync<HotelReservation>(query, new { Id }));
            //}
        }

        public async Task<int> AddAsync(HotelReservation hotelReservation)
        {
            await _context.HotelReservations.AddAsync(hotelReservation);
            await _context.SaveChangesAsync();
            return hotelReservation.HotelReservationId;

            //var sb = new StringBuilder();

            //sb.AppendLine("INSERT INTO HotelReservation (HotelId, RoomTypeId, CheckInDate, CheckOutDate, TotalPrice)");
            //sb.AppendLine("VALUES (@HotelId, @RoomTypeId, @CheckInDate, @CheckOutDate, @TotalPrice);");
            //sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    var id = await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.QuerySingleAsync<int>(query, hotelReservation));
            //    return id;
            //}
        }

        public async Task DeleteByIdAsync(int id)
        {
            var hotelReservation = await (from hr in _context.HotelReservations.AsNoTracking()
                                          where hr.HotelReservationId == id
                                          select hr).FirstOrDefaultAsync();

            //var hotelReservation = await _context.HotelReservations.FindAsync(id);

            if (hotelReservation != null) 
            {
                _context.Remove(hotelReservation);
                await _context.SaveChangesAsync();
            }

            //var sb = new StringBuilder();

            //sb.AppendLine("DELETE FROM HotelReservation");
            //sb.AppendLine("WHERE Id = @Id");

            //var query = sb.ToString();

            //using (var connection = _context.CreateConnection())
            //{
            //    await CircuitBreakerPolicy.ResiliencePolicy.ExecuteAsync(() =>
            //        connection.ExecuteAsync(query, new { id }));
            //}
        }
    }
}
