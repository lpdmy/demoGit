using FluentValidation;
using System.Net;
using System.Text.Json;
using TeachMate.Domain;

namespace TeachMate.Api;
public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Message from GlobalExceptionHandlerMiddleware: {ex.Message}");

            await HandleExceptionAsync(context, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var request = context.Request;
        var response = context.Response;

        response.ContentType = "application/json";

        response.StatusCode = ex switch
        {
            ValidationException => (int)HttpStatusCode.BadRequest,
            BadRequestException => (int)HttpStatusCode.BadRequest,
            UnauthorizedException => (int)HttpStatusCode.Unauthorized,
            ForbiddenException => (int)HttpStatusCode.Forbidden,
            NotFoundException => (int)HttpStatusCode.NotFound,
            ConflictException => (int)HttpStatusCode.Conflict,
            _ => (int)HttpStatusCode.InternalServerError,
        };

        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var result = JsonSerializer.Serialize(new ErrorResponseDto
        {
            StatusCode = response.StatusCode,
            Message = ex.Message,
            Path = request.Path.Value,
            Timestamp = DateTime.UtcNow
        }, serializeOptions);

        await response.WriteAsync(result);
    }
}
public static class GlobalExceptionHandlerMidddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}

