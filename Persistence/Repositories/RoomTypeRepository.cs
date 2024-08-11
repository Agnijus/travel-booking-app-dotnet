
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Exceptions;
using Application.Models;


namespace Persistence.Repositories
{
    public class RoomTypeRepository : IRoomTypeRespository
    {
        private readonly DbContextMembers _context;

        public RoomTypeRepository(DbContextMembers context)
        {
            _context = context;
        }

        public async Task<RoomType> GetByIdAsync(int id)
        {
            var roomType = await (from r in _context.RoomTypes.AsNoTracking()
                                 where r.RoomTypeId == id
                                 select r).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(string.Format(Constant.RoomTypeNotFoundError, id));

            return roomType;
        }
    }
}
