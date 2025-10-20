using System.Net;
using System.Text.Json;
using CandidatesTestProject.Exceptions;

namespace CandidatesTestProject.Middleware;

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
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "An internal server error occurred.";

        switch (exception)
        {
            case AppException appException:
                statusCode = (HttpStatusCode)appException.StatusCode;
                message = appException.Message;
                
                if (statusCode == HttpStatusCode.Unauthorized)
                {
                    _logger.LogWarning(exception, "Unauthorized access attempt: {Message}", message);
                }
                else if (statusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogWarning(exception, "Bad request: {Message}", message);
                }
                else
                {
                    _logger.LogError(exception, "Application exception occurred: {Message}", message);
                }
                break;

            default:
                _logger.LogCritical(exception, "Unhandled exception occurred: {Message}", exception.Message);
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            error = message,
            statusCode = (int)statusCode,
            timestamp = DateTime.UtcNow
        };

        var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(jsonResponse);
    }
}

