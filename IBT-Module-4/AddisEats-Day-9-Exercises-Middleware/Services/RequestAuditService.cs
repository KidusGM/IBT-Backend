namespace AddisEatsNew.Api.Services;

public sealed class RequestAuditService
{
    private readonly ILogger<RequestAuditService> _logger;
    private readonly Guid _instanceId = Guid.NewGuid();

    public RequestAuditService(ILogger<RequestAuditService> logger)
        => _logger = logger;

    public void Record(string message)
    {
        _logger.LogInformation(
            "AuditServiceInstance={InstanceId}; {Message}",
            _instanceId,
            message);
    }
}
