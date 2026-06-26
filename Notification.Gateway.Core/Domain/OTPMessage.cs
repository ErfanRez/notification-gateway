using Notification.Gateway.Core.Abstractions;

namespace Notification.Gateway.Core.Domain;

public sealed class OTPMessage(string recipient, string content) : BaseMessage(recipient, content)
{
}
