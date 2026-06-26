using Notification.Gateway.Core.Models;

namespace Notification.Gateway.Core.Abstractions;

public interface IMessageFactory
{
    Message CreateMessage(string recipient, string content);
}
