namespace travel_app.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } = 200;
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }

        public ApiResponse(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            IsSuccess = statusCode == 200;
            Message = message;
            Data = data;
        }

        public ApiResponse(int statusCode, bool isSuccess, string message)
        {
            StatusCode = statusCode;
            IsSuccess = isSuccess;
            Message = message;
        }

        public ApiResponse(string message, object data)
            : this(200, message, data)
        {
        }
        

        public ApiResponse(string message)
            : this(200, message, null)
        {
        }

        public ApiResponse()
        {
        }
    }
}
