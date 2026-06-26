namespace Notification.Gateway.Core.Models;

public sealed class OTPMessage(string recipient, string content) : Message(recipient, content)
{
    public override void UpdateStatus(MessageStatus status)
    {
        Status = status;
    }
}
