using System.Net;
using System.Text.Json;

namespace SchoolApi.CustomMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware>? _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware>? logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unhandled exception occurred: {ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        public Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                success = false,
                message = "An unexpected error occurred.",
                detail = ex.Message
            };
            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
