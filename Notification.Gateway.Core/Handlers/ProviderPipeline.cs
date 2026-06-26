using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Domain;
using Notification.Gateway.Core.Providers;

namespace Notification.Gateway.Core.Handlers;

internal sealed class ProviderPipeline : IProviderPipeline
{
    private readonly IProviderHandler _firstHandler;

    public ProviderPipeline(
    ProviderHandler<ProviderA> providerAHandler,
    ProviderHandler<ProviderB> providerBHandler)
    {
        providerAHandler
            .SetNext(providerBHandler);

        _firstHandler = providerAHandler;
    }

    public Task<SendResult> SendAsync(BaseMessage message)
    {
        return _firstHandler.HandleAsync(message);
    }
}