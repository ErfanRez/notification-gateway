using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Domain;
using Notification.Gateway.Core.Events;

namespace Notification.Gateway.Core.Handlers;

internal class ProviderHandler<TProvider> : BaseProviderHandler
    where TProvider : ISmsProvider
{
    private readonly TProvider _provider;
    private readonly NotificationEventPublisher _events;

    public ProviderHandler(
        TProvider provider,
        NotificationEventPublisher events)
    {
        _provider = provider;
        _events = events;
    }

    public override async Task<SendResult> HandleAsync(BaseMessage message)
    {

        _events.RaiseProviderSelected(message, _provider.Name);

        var result = await _provider.SendAsync(message);

        if (result.Success)
        {
            _events.RaiseMessageSent(message, _provider.Name);
            return result;
        }

        _events.RaiseMessageFailed(message, _provider.Name);

        if (Next is not null)
        {
            _events.RaiseProviderChanged(message);

            return await Next.HandleAsync(message);
        }


        return result;
    }
}
