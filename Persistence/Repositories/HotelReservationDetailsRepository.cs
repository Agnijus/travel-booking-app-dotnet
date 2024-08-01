using Dapper;
using Domain.Entities;
using Domain.Repository_Interfaces;
using System.Text;

namespace Persistence.Repositories
{
    public class HotelReservationDetailsRepository : IHotelReservationDetailsRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelReservationDetailsRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HotelReservation> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT r.HotelId, r.RoomTypeId, r.CheckInDate, r.CheckOutDate, r.TotalPrice");
            sb.AppendLine("FROM HotelReservation r");
            sb.AppendLine("WHERE r.Id = @id");

            var query = sb.ToString();
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<HotelReservation>(
                new CommandDefinition(query, new { id }, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
        }

        public async Task<int> AddAsync(HotelReservation hotelReservation, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO HotelReservation (HotelId, RoomTypeId, CheckInDate, CheckOutDate, TotalPrice)");
            sb.AppendLine("VALUES (@HotelId, @RoomTypeId, @CheckInDate, @CheckOutDate, @TotalPrice);");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");

            var query = sb.ToString();
            return await _unitOfWork.Connection.QuerySingleAsync<int>(
                new CommandDefinition(query, hotelReservation, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DELETE FROM HotelReservation");
            sb.AppendLine("WHERE Id = @Id");

            var query = sb.ToString();
            await _unitOfWork.Connection.ExecuteAsync(
                new CommandDefinition(query, new { id }, transaction: _unitOfWork.Transaction, cancellationToken: cancellationToken));
        }
    }
}
