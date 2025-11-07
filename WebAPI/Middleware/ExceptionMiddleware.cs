using Infrastructure.Exceptions;
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
        catch(NoDataFoundException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(ex.Message);
        }
        catch (Exception ex)
        {
#if DEBUG
            logger.LogError(ex.Message);
#endif


            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync("Server error");
        }
    }
}