using Domain.Exceptions;
using System.Net;
using System.Text.Json;
using travel_app.Models;
using Serilog;


namespace travel_app.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case EntityNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case ArgumentNullException:
                case InvalidOperationException:
                case ArgumentException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case NotSupportedException:
                    code = HttpStatusCode.MethodNotAllowed;
                    break;
                case DatabaseConnectionException:
                    code = HttpStatusCode.ServiceUnavailable;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var isSuccess = false;
            var errorMessage = exception.Message;

            var response = new ApiResponse((int)code, isSuccess, errorMessage);
            var jsonResponse = JsonSerializer.Serialize(response);

            Log.Error(exception.InnerException, $"Error {code}");

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
