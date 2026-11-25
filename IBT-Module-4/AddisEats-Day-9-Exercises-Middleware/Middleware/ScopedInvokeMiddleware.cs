using AddisEatsNew.Api.Services;

namespace AddisEatsNew.Api.Middleware;

// Exercise 5B: correct pattern. ASP.NET Core resolves this scoped parameter
// separately for each request.
public sealed class ScopedInvokeMiddleware
{
    private readonly RequestDelegate _next;

    public ScopedInvokeMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(
        HttpContext context,
        RequestAuditService audit)
    {
        audit.Record("InvokeAsync middleware entered");
        await _next(context);
    }
}
