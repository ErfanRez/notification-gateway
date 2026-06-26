using Notification.Gateway.Core.Domain;

namespace Notification.Gateway.Core.Abstractions;

internal interface ISmsProvider
{
    string Name { get; }
    Task<SendResult> SendAsync(BaseMessage message);
}
