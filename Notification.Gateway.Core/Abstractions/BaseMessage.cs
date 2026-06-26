using Notification.Gateway.Core.Domain;

namespace Notification.Gateway.Core.Abstractions;

public abstract class BaseMessage
{
    public Guid Id { get; init; }
    public string Recipient { get; init; }
    public string Content { get; init; }
    public DateTime CreatedAt { get; init; }
    public MessageStatus Status { get; protected set; }

    protected BaseMessage(string recipient, string content)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Status = MessageStatus.Created;

        Recipient = recipient;
        Content = content;
    }

    public virtual void UpdateStatus(MessageStatus status)
    {
        Status = status;
    }
}
