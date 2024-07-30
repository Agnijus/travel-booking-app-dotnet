using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;
using System.Text;

namespace Persistence.Repositories
{
    public class HotelReservationDetailsRepository : IHotelReservationDetailsRepository
    {
        private readonly IDapperContext _context;

        public HotelReservationDetailsRepository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<HotelReservation> GetByIdAsync(int Id)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT r.HotelId, r.RoomTypeId, r.CheckInDate, r.CheckOutDate, r.TotalPrice");
            sb.AppendLine("FROM HotelReservation r");
            sb.AppendLine("WHERE r.Id = @id");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<HotelReservation>(query, new { Id });
            }
        }

        public async Task<int> AddAsync(HotelReservation hotelReservation)
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO HotelReservation (HotelId, RoomTypeId, CheckInDate, CheckOutDate, TotalPrice)");
            sb.AppendLine("VALUES (@HotelId, @RoomTypeId, @CheckInDate, @CheckOutDate, @TotalPrice);");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                
                var id = await connection.QuerySingleAsync<int>(query, hotelReservation);
                return id;
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var sb = new StringBuilder();

            sb.AppendLine("DELETE FROM GuestAccounts");
            sb.AppendLine("WHERE Id = @Id");

            var query = sb.ToString();

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
