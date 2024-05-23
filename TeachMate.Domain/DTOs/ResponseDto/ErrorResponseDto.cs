using System.Net;

namespace TeachMate.Domain;
public class ErrorResponseDto
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
    public string Message { get; set; } = string.Empty;
    public string? Path { get; set; }
    public DateTime Timestamp { get; set; }
}
