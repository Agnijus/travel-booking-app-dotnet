using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class GuestAccountRepository : IGuestAccountRepository
    {
        public GuestAccount GetByIdAsync(int Id)
        {
            var guestAccounts = GuestAccountData.GuestAccounts.FirstOrDefault(b => b.Id == Id);
            return guestAccounts;
        }

        public void Add(GuestAccount guestAccount)
        {
            guestAccount.Id = GuestAccountData.GetNextId();
            GuestAccountData.GuestAccounts.Add(guestAccount);
        }

        public void Delete(GuestAccount guestAccount)
        {
            GuestAccountData.GuestAccounts.Remove(guestAccount);
        }
    }
}
