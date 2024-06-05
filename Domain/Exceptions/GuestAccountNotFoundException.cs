using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Exceptions;

namespace Domain.Exceptions
{
    public class GuestAccountNotFoundException : NotFoundException
    {
        public GuestAccountNotFoundException(int id)
           : base($"The guest account with the identifier {id} was not found.")
        {
        }
    }
}
