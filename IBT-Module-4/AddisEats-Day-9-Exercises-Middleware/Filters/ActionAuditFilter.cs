using Microsoft.AspNetCore.Mvc.Filters;

namespace AddisEatsNew.Api.Filters;

public sealed class ActionAuditFilter : IAsyncActionFilter
{
    private readonly ILogger<ActionAuditFilter> _logger;

    public ActionAuditFilter(ILogger<ActionAuditFilter> logger)
        => _logger = logger;

    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        var actionName = context.ActionDescriptor.DisplayName ?? "Unknown action";

        _logger.LogInformation(
            "Action audit: {ActionName}; Bound arguments: {@Arguments}",
            actionName,
            context.ActionArguments);

        await next();
    }
}
