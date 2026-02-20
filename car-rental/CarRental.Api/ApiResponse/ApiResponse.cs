namespace car_rental_api.ApiResponse;

public class ApiResponse<T>
{
    public string Status { get; set; } = null!;
    public T Data { get; set; } = default!;
    public string ErrorCode { get; set; } = null!;
    public string Message { get; set; } = null!;
}