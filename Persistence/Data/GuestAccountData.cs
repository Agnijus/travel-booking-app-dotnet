using Domain.Entities;

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
