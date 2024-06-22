
using travel_app.Core.Exceptions;

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
