using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_booking_app_dotnet.Core.Exceptions;

namespace Domain.Exceptions
{
    public sealed class HotelNotFoundException : NotFoundException
    {

        public HotelNotFoundException(int id)
            : base($"The hotel with the identifier {id} was not found.")
        {
        }

    }
}
