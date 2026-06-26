using Notification.Gateway.Core.Abstractions;

namespace Notification.Gateway.Core.Events;

public sealed class NotificationEventArgs : EventArgs
{
    public BaseMessage Message { get; }

    public string? ProviderName { get; }

    public NotificationEventArgs(BaseMessage message, string? providerName = null)
    {
        Message = message;
        ProviderName = providerName;
    }
}
