using Microsoft.Extensions.Logging;
using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Domain;

namespace Notification.Gateway.Core.Providers;

internal class ProviderA : ISmsProvider
{
    private readonly ILogger<ProviderA> _logger;

    public ProviderA(ILogger<ProviderA> logger)
    {
        _logger = logger;
    }

    public string Name => "Provider A";

    public Task<SendResult> SendAsync(BaseMessage message)
    {
        _logger.LogInformation("Sending message...");
        // Simulate 70% success rate
        var success = Random.Shared.Next(1, 101) <= 70;

        return Task.FromResult(
            success
                ? SendResult.Successful(Name)
                : SendResult.Failed(Name, "Couldn't proccess"));
    }
}
