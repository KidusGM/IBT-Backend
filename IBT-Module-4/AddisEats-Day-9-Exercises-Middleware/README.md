# ASP.NET Core Middleware Exercises

These files are intended to be copied into the `AddisEatsNew.Api` ASP.NET Core project.
Namespace used: `AddisEatsNew.Api`. Adjust it only if your project namespace differs.

## Files

- `Middleware/CorrelationIdMiddleware.cs`
- `Middleware/RequestTimingMiddleware.cs`
- `Middleware/ApiKeyMiddleware.cs`
- `Middleware/ScopedConventionMiddleware.cs`
- `Middleware/ScopedInvokeMiddleware.cs`
- `Services/RequestAuditService.cs`
- `Filters/ActionAuditFilter.cs`
- `Controllers/AdminController.cs`
- `Controllers/AuditDemoController.cs`
- `Models/CorrelationResponse.cs`
- `Program.cs`

## Configuration

Add `AdminApiKey` to user secrets or environment variables. Do not commit a real key.
For local testing, the example file is `appsettings.Development.example.json`; copy its
setting into your local `appsettings.Development.json` (do not commit secrets).

## Exercise 1 — Correlation ID

Send `X-Correlation-Id` with a request. The middleware accepts it, otherwise generates
a GUID. It sets `HttpContext.TraceIdentifier` and returns the same value in the response
header.

## Exercise 2 — Request timing

The timing middleware logs method, path, response status, elapsed milliseconds, and
correlation ID. It uses Information at or below 1000 ms and Warning above 1000 ms.

## Exercise 3 — API key on only /admin

The `/admin` branch has `ApiKeyMiddleware`; the rest of the app does not. Send the
`X-Admin-Api-Key` header to access `/admin/health`. Missing or incorrect key returns 401.

## Exercise 4 — Scoped service in middleware

### Incorrect constructor-injected version

Uncomment `app.UseMiddleware<ScopedConventionMiddleware>();` and comment out the
`ScopedInvokeMiddleware` registration. Run two simultaneous requests, for example:

```powershell
1..2 | ForEach-Object -Parallel { Invoke-WebRequest http://localhost:5000/api/audit-demo/1 }
```

Expected observation: startup/request activation fails because conventional middleware is
constructed by the application pipeline and cannot receive a scoped service in its
constructor. The exact exception text depends on ASP.NET Core version and validation.

### Correct InvokeAsync version

Comment out the convention middleware and uncomment
`app.UseMiddleware<ScopedInvokeMiddleware>();`. Repeat the simultaneous requests.
The scoped service is resolved per request. Compare `AuditServiceInstance` GUIDs in the
logs: concurrent requests should normally show different scoped instances.

Record your actual output here:
- Convention middleware output:
- InvokeAsync middleware output:

## Exercise 5 — Authentication/authorization order (scratch branch)

In a separate branch, swap:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

to the incorrect order:

```csharp
app.UseAuthorization();
app.UseAuthentication();
```

Call an endpoint protected by `[Authorize]` with a valid authentication credential.
Record the exact HTTP response and log output from your environment. Do not invent
a universal response: behavior depends on the authentication scheme, endpoint, and
ASP.NET Core version. Restore the correct order afterward.

## Exercise 6 — Action audit filter

`ActionAuditFilter` logs the action display name and `ActionArguments`, which are the
arguments after model binding. Try:

```http
GET /api/audit-demo/42?note=hello
```

Middleware cannot log *bound action arguments* because middleware runs before MVC
model binding and action selection; an MVC action filter runs at the action boundary.

## Program.cs pipeline, line by line

1. `UseMiddleware<CorrelationIdMiddleware>()` assigns the request identifier before
   downstream logging.
2. `UseMiddleware<RequestTimingMiddleware>()` wraps the rest of the pipeline and logs
   the final response status and duration, including when downstream throws.
3. `UseAuthentication()` establishes the user identity from the configured scheme.
4. `UseAuthorization()` evaluates endpoint authorization after authentication.
5. `Map("/admin", ...)` creates a branch; the API-key check applies only under `/admin`.
6. `MapControllers()` maps MVC controller endpoints.
7. `app.Run()` starts the application and terminates pipeline configuration.

## One commit per exercise

The instructions describe eight exercises. Treat the pipeline registration/verification
as its own commit so each exercise has one commit. Suggested eight-commit sequence:

```text
git add Middleware/CorrelationIdMiddleware.cs && git commit -m "Add correlation ID middleware"
git add Middleware/RequestTimingMiddleware.cs && git commit -m "Add request timing middleware"
git add Program.cs && git commit -m "Register correlation and timing middleware"
git add Middleware/ApiKeyMiddleware.cs Program.cs && git commit -m "Protect admin branch with API key"
git add Middleware/ScopedConventionMiddleware.cs Middleware/ScopedInvokeMiddleware.cs Services/RequestAuditService.cs && git commit -m "Demonstrate scoped middleware lifetime"
git add Program.cs && git commit -m "Test authentication authorization order"
git add Filters/ActionAuditFilter.cs Controllers/AuditDemoController.cs && git commit -m "Add MVC action audit filter"
git add README.md && git commit -m "Document middleware pipeline"
```
