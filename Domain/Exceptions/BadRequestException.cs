namespace travel_booking_app_dotnet.Core.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message): base(message) { }
    }
}
