namespace AddisEatsNew.Api.Middleware
{
    public class CorrelationMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<CorrelationMiddleware> _logger;

        public CorrelationMiddleware(RequestDelegate next, ILogger<CorrelationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId =
                context.Request.Headers["X-Correlation-Id"].ToString();

            if (string.IsNullOrWhiteSpace(correlationId))

            {
                correlationId = Guid.NewGuid().ToString("N");
            }
            context.TraceIdentifier = correlationId;
            context.Response.Headers["X-Correlation-Id"] = correlationId;

            using (_logger.BeginScope(
                new Dictionary<string, object>
                {
                    ["Correlation-Id"] = correlationId
                }
                ))

            { 
            await _next(context);
            }


        }
    }
}
