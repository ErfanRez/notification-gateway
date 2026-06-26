using Notification.Gateway.Core.Domain;

namespace Notification.Gateway.Core.Abstractions;

internal interface IProviderHandler
{
    Task<SendResult> HandleAsync(BaseMessage message);
}
