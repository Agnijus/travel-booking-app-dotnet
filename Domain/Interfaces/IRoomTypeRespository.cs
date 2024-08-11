using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRoomTypeRespository
    {
        Task<RoomType> GetByIdAsync(int id);
    }
}
