using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GuestAccountRepository : IGuestAccountRepository
    {
        public Task<GuestAccount> GetByIdAsync(int Id)
        {
            var guestAccounts = GuestAccountData.GuestAccounts.FirstOrDefault(b => b.Id == Id);
            return Task.FromResult(guestAccounts);
        }

        public void Insert(GuestAccount guestAccount)
        {
            GuestAccountData.GuestAccounts.Add(guestAccount);
        }

        public void Remove(GuestAccount guestAccount)
        {
            GuestAccountData.GuestAccounts.Remove(guestAccount);
        }
    }
}
