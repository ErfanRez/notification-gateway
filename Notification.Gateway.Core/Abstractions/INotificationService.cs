namespace Notification.Gateway.Core.Abstractions;

public interface INotificationService
{
    Task SendAsync(BaseMessage message);
}
