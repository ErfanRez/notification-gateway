using Microsoft.Extensions.Logging;
using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Domain;
using Notification.Gateway.Core.Events;

namespace Notification.Gateway.Core.Services;

public sealed class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _logger;
    private readonly IProviderPipeline _pipeline;
    private readonly NotificationEventPublisher _events;

    public NotificationService(
        IProviderPipeline pipeline,
        NotificationEventPublisher events,
        ILogger<NotificationService> logger)
    {
        _pipeline = pipeline;
        _events = events;
        _logger = logger;
    }

    public async Task SendAsync(BaseMessage message)
    {
        _logger.LogInformation("Creating Message...");

        _events.RaiseMessageCreated(message);

        message.UpdateStatus(MessageStatus.Sending);

        var result = await _pipeline.SendAsync(message);

        message.UpdateStatus(
            result.Success
                ? MessageStatus.Sent
                : MessageStatus.Failed);

        _logger.LogInformation("Final status: {Status}", message.Status);

        Console.WriteLine();
    }
}
