using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    internal class GuestAccountData
    {

        private static int lastId = 0;

        public static List<GuestAccount> GuestAccounts { get; } = new List<GuestAccount>
        {

        };

        public static int GetNextId()
        {
            return ++lastId;
        }
    }
}
