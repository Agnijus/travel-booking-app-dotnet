using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Entities;

namespace Domain.Repository_Interfaces
{
    public interface IGuestAccountRepository
    {
        GuestAccount GetByIdAsync(int Id);

        void Insert(GuestAccount guestAccount);
        void Remove(GuestAccount guestAccount);
    }
}
