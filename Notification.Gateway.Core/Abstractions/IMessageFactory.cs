namespace Notification.Gateway.Core.Abstractions;

public interface IMessageFactory
{
    BaseMessage CreateMessage(string recipient, string content);
}
