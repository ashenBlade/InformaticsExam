namespace AspNetCoreSampleApp;

public static class SampleMiddlewareExtensions
{
    public static WebApplication UseTime(this WebApplication app)
    {
        app.UseMiddleware<TimeMiddleware>();
        return app;
    }
}