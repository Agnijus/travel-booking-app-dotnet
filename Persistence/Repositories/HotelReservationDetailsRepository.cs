using Dapper;
using Domain.Entities;
using Domain.Enums;
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
            var query = "SELECT * FROM HotelReservationDetails WHERE id = @id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<HotelReservation>(query, new { Id });
            }
        }

        public async Task<int> AddAsync(HotelReservation hotelReservation)
        {
            var query = @"
            INSERT INTO HotelReservationDetails (HotelId, RoomType, CheckInDate, CheckOutDate, TotalPrice) 
            VALUES (@HotelId, @RoomType, @CheckInDate, @CheckOutDate, @TotalPrice);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    HotelId = hotelReservation.HotelId,
                    RoomType = hotelReservation.RoomType.ToString(),
                    CheckInDate = hotelReservation.CheckInDate,
                    CheckOutDate = hotelReservation.CheckOutDate,
                    TotalPrice = hotelReservation.TotalPrice
                };

                var id = await connection.QuerySingleAsync<int>(query, parameters);
                return id;
            }
        }

        public async Task DeleteAsync(HotelReservation hotelBooking)
        {
            var query = "DELETE FROM GuestAccounts WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = hotelBooking.Id });
            }
        }
    }
}
