using Microsoft.Extensions.Logging;

namespace Notification.Gateway.Core.Events;

public sealed class NotificationLogger
{
    public NotificationLogger(
        NotificationEventPublisher publisher,
        ILogger<NotificationLogger> logger)
    {
        publisher.MessageCreated += (_, e) =>
            logger.LogInformation(
                "Message {Id} created.",
                e.Message.Id);

        publisher.ProviderSelected += (_, e) =>
            logger.LogInformation(
                "{Provider} selected.",
                e.ProviderName);

        publisher.ProviderChanged += (_, e) =>
            logger.LogInformation(
                "Switching provider ...");

        publisher.MessageSent += (_, e) =>
            logger.LogInformation(
                "Message {Id} sent successfully via {Provider}.",
                e.Message.Id,
                e.ProviderName);

        publisher.MessageFailed += (_, e) =>
            logger.LogInformation(
                "{Provider} failed.",
                e.ProviderName);
    }
}
