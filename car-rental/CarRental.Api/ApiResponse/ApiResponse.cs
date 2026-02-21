namespace car_rental_api.ApiResponse;

public class ApiResponse<T>
{
    public string Status { get; set; } = null!;
    public T Data { get; set; } = default!;
    public string ErrorCode { get; set; } = null!;
    public string Message { get; set; } = null!;
    
    public static ApiResponse<T> Success(T data, string message = "Success")
        => new ApiResponse<T>
        {
            Status = "Success",
            Data = data,
            Message = message
        };

    public static ApiResponse<T> Failure(string errorCode, string message)
        => new ApiResponse<T>
        {
            Status = "Failure",
            ErrorCode = errorCode,
            Message = message
        };
}