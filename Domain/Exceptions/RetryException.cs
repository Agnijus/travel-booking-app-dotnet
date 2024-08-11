

namespace Domain.Exceptions
{
    public class RetryException : Exception
    {
        public RetryException(string message)
            : base(message)
        {
        }
    }
}
