using Domain.Entities;

namespace Domain.Repository_Interfaces
{
    public interface IGuestAccountRepository
    {
        Task<GuestAccount> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> AddAsync(GuestAccount guestAccount, CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
