using AddisEatsNew.Api.Services;

namespace AddisEatsNew.Api.Middleware;

// Exercise 5A: intentionally inject a scoped service into the convention
// middleware constructor. This is incorrect because middleware is constructed
// once for the application, not once per request.
public sealed class ScopedConventionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly RequestAuditService _audit;

    public ScopedConventionMiddleware(
        RequestDelegate next,
        RequestAuditService audit)
    {
        _next = next;
        _audit = audit;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _audit.Record("Convention middleware entered");
        await _next(context);
    }
}
