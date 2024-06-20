using Domain.Entities;

namespace Domain.Repository_Interfaces
{
    public interface IGuestAccountRepository
    {
        Task<GuestAccount> GetByIdAsync(int Id);
        Task<int> AddAsync(GuestAccount guestAccount);
        Task DeleteAsync(GuestAccount guestAccount);
    }
}
