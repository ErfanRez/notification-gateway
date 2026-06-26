using Notification.Gateway.Core.Domain;

namespace Notification.Gateway.Core.Abstractions;

internal abstract class BaseProviderHandler : IProviderHandler
{
    protected IProviderHandler? Next;

    public IProviderHandler SetNext(IProviderHandler nextHandler)
    {
        Next = nextHandler;
        return nextHandler;
    }

    public abstract Task<SendResult> HandleAsync(BaseMessage message);
}
