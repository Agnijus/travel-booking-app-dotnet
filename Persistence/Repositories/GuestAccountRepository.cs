﻿using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;

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
            guestAccount.Id = GuestAccountData.GetNextId();
            GuestAccountData.GuestAccounts.Add(guestAccount);
        }

        public void Remove(GuestAccount guestAccount)
        {
            GuestAccountData.GuestAccounts.Remove(guestAccount);
        }
    }
}
