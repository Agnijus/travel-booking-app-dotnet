namespace travel_app.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } = 200;
        public string? Message { get; set; }
        public object? Data { get; set; }

        public ApiResponse(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public ApiResponse(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public ApiResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
