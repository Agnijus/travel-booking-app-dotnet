using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Exceptions;

namespace Domain.Exceptions
{
    public class BookingNotFoundException : NotFoundException
    {
        public BookingNotFoundException(int id)
           : base($"The booking with the identifier {id} was not found.")
        {
        }
    }
}
