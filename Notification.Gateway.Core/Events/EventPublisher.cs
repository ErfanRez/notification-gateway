using Notification.Gateway.Core.Abstractions;

namespace Notification.Gateway.Core.Events;

public sealed class NotificationEventPublisher
{
    public event EventHandler<NotificationEventArgs>? MessageCreated;

    public event EventHandler<NotificationEventArgs>? ProviderSelected;

    public event EventHandler<NotificationEventArgs>? ProviderChanged;

    public event EventHandler<NotificationEventArgs>? MessageSent;

    public event EventHandler<NotificationEventArgs>? MessageFailed;

    internal void RaiseMessageCreated(BaseMessage message)
        => MessageCreated?.Invoke(this, new(message));

    internal void RaiseProviderSelected(BaseMessage message, string provider)
        => ProviderSelected?.Invoke(this, new(message, provider));

    internal void RaiseProviderChanged(BaseMessage message)
        => ProviderChanged?.Invoke(this, new(message));

    internal void RaiseMessageSent(BaseMessage message, string provider)
        => MessageSent?.Invoke(this, new(message, provider));

    internal void RaiseMessageFailed(BaseMessage message, string provider)
        => MessageFailed?.Invoke(this, new(message, provider));
}
