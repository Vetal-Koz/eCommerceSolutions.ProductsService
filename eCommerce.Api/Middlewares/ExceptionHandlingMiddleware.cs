using eCommerce.Core.Exceptions;

namespace eCommerce.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"{ex.GetType().ToString()}: {ex.Message}");

            if (ex.InnerException != null)
            {
                _logger.LogError($"{ex.InnerException.GetType().ToString()}: {ex.InnerException.Message}");
            }

            int statusCode = ex switch
            {
                EntityNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            
            httpContext.Response.StatusCode = statusCode; 
            await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString() });
        }
        
        
    }
    
}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}