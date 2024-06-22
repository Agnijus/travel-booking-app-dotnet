namespace travel_app.Core.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message): base(message) { }
    }
}
