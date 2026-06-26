using Notification.Gateway.Core.Domain;

namespace Notification.Gateway.Core.Abstractions;

public interface IProviderPipeline
{
    Task<SendResult> SendAsync(BaseMessage message);
}
