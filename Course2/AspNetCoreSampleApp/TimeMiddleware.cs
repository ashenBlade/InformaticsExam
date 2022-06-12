using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreSampleApp;

public class TimeMiddleware: IMiddleware
{
    private readonly ITimeService _timeService;

    public TimeMiddleware(ITimeService timeService)
    {
        _timeService = timeService;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path == "/time")
        {
            await context.Response.WriteAsJsonAsync(new {Time = _timeService.GetCurrentTime()});
        }
        else
        {
            await next(context);
        }
    }
}