using Domain.Entities;

namespace Domain.Repository_Interfaces
{
    public interface IGuestAccountRepository
    {
        Task<GuestAccount?> GetByIdAsync(int id);
        Task<int> AddAsync(GuestAccount guestAccount);
        Task DeleteByIdAsync(int id);
    }
}
