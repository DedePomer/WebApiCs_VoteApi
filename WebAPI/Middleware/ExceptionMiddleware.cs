using Microsoft.AspNetCore.Http.HttpResults;

namespace WebAPI.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            
            context.Response.StatusCode = 500;   
            await context.Response.WriteAsJsonAsync("Server error");
        }
    }
}