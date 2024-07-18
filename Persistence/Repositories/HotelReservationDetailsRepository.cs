using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class HotelReservationDetailsRepository : IHotelReservationDetailsRepository
    {
        private readonly DapperContext _context;

        public HotelReservationDetailsRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<HotelReservation> GetByIdAsync(int Id)
        {
            var query = "SELECT * FROM HotelReservation WHERE id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<HotelReservation>(query, new { Id });
            }
        }

        public async Task<int> AddAsync(HotelReservation hotelReservation)
        {
            var query = @"
            INSERT INTO HotelReservation (HotelId, RoomTypeId, CheckInDate, CheckOutDate, TotalPrice) 
            VALUES (@HotelId, @RoomTypeId, @CheckInDate, @CheckOutDate, @TotalPrice);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                
                var id = await connection.QuerySingleAsync<int>(query, hotelReservation);
                return id;
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var query = "DELETE FROM GuestAccounts WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
