using Domain.Entities;

namespace Domain.Repository_Interfaces
{
    public interface IGuestAccountRepository
    {
        GuestAccount GetByIdAsync(int Id);

        void Add(GuestAccount guestAccount);
        void Delete(GuestAccount guestAccount);
    }
}
