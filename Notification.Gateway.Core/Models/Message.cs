namespace Notification.Gateway.Core.Models;

public abstract class Message
{
    public Guid Id { get; init; }
    public string Recipient { get; init; }
    public string Content { get; init; }
    public DateTime CreatedAt { get; init; }
    public MessageStatus Status { get; protected set; }

    protected Message(string recipient, string content)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Status = MessageStatus.Created;

        Recipient = recipient;
        Content = content;
    }

    public abstract void UpdateStatus(MessageStatus status);
}
