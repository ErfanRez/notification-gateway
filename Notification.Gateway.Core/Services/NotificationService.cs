using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Domain;
using Notification.Gateway.Core.Events;

namespace Notification.Gateway.Core.Services;

public sealed class NotificationService : INotificationService
{
    private readonly IProviderPipeline _pipeline;
    private readonly NotificationEventPublisher _events;

    public NotificationService(
        IProviderPipeline pipeline,
        NotificationEventPublisher events)
    {
        _pipeline = pipeline;
        _events = events;
    }

    public async Task SendAsync(BaseMessage message)
    {
        Console.WriteLine("Creating Message...");

        _events.RaiseMessageCreated(message);

        message.UpdateStatus(MessageStatus.Sending);

        var result = await _pipeline.SendAsync(message);

        message.UpdateStatus(
            result.Success
                ? MessageStatus.Sent
                : MessageStatus.Failed);

        Console.WriteLine($"Final status: {message.Status}");
    }
}
