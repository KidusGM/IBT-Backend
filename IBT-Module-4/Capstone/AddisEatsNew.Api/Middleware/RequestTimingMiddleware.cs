using System.Diagnostics;
namespace AddisEatsNew.Api.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        { 
         var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            var logLevel = elapsedMilliseconds > 1000
                ? LogLevel.Warning
                : LogLevel.Information;


            _logger.Log(
                logLevel,
                "{Method} {Path} -> {Status} in {Ms}ms",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                elapsedMilliseconds


                );
        }
            
    }
}
