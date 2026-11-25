
using AddisEatsNew.Api.Filters;
using AddisEatsNew.Api.Middleware;
using AddisEatsNew.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<RequestAuditService>();
builder.Services.AddScoped<ActionAuditFilter>();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Correlation must run before timing so the timing log includes the ID.
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();

// Authentication must precede authorization when both are configured.
app.UseAuthentication();
app.UseAuthorization();

// Only requests whose path starts with /admin enter this branch.
// The branch path is stripped, so its endpoint is /health.
app.Map("/admin", adminApp =>
{
    adminApp.UseMiddleware<ApiKeyMiddleware>();
    adminApp.Run(async context =>
    {
        if (context.Request.Path == "/health")
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync("{\"status\":\"admin ok\"}");
            return;
        }

        context.Response.StatusCode = StatusCodes.Status404NotFound;
    });
});

app.MapControllers();

// Exercise 5: enable ONE version at a time.
// Uncomment convention version to observe the scoped-service activation error.
// app.UseMiddleware<ScopedConventionMiddleware>();
// Correct version resolves the scoped service per request.
// app.UseMiddleware<ScopedInvokeMiddleware>();

app.Run();
