
using System.Diagnostics;

namespace Restaurants.API.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        await next.Invoke(context);
        stopWatch.Stop();
        if(stopWatch.ElapsedMilliseconds >= 4000)
        {
            logger.LogInformation($"{context.Request.Method} {context.Request.Path} took {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}
