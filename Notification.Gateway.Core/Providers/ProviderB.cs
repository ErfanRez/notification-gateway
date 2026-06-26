using Microsoft.Extensions.Logging;
using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Domain;

namespace Notification.Gateway.Core.Providers;

internal class ProviderB : ISmsProvider
{
    private readonly ILogger<ProviderB> _logger;

    public ProviderB(ILogger<ProviderB> logger)
    {
        _logger = logger;
    }

    public string Name => "Provider B";

    public Task<SendResult> SendAsync(BaseMessage message)
    {
        _logger.LogInformation("Sending message...");
        // Simulate 90% success rate
        var success = Random.Shared.Next(1, 101) <= 90;

        return Task.FromResult(
            success
                ? SendResult.Successful(Name)
                : SendResult.Failed(Name, "Couldn't proccess"));
    }
}
