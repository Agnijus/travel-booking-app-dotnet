
using travel_app.Core.Exceptions;

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
