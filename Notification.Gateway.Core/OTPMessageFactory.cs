using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Models;

namespace Notification.Gateway.Core;

public class OTPMessageFactory : IMessageFactory
{
    public Message CreateMessage(string recipient, string code)
    {
        return new OTPMessage(recipient, code);
    }
}
