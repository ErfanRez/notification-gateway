using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Domain;

namespace Notification.Gateway.Core.Factories;

public class OTPMessageFactory : IMessageFactory
{
    public BaseMessage CreateMessage(string recipient, string code)
    {
        return new OTPMessage(
            recipient,
            $"Your verification code is {code}");
    }
}
