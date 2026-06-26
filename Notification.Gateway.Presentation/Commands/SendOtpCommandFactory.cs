using Notification.Gateway.Core.Abstractions;

namespace Notification.Gateway.Presentation.Commands;

internal sealed class SendOtpCommandFactory : ISendOtpCommandFactory
{
    private readonly IMessageFactory _messageFactory;
    private readonly INotificationService _notificationService;

    public SendOtpCommandFactory(
        IMessageFactory messageFactory,
        INotificationService notificationService)
    {
        _messageFactory = messageFactory;
        _notificationService = notificationService;
    }

    public ICommand Create(
        string recipient,
        string code)
    {
        return new SendOtpCommand(
            _messageFactory,
            _notificationService,
            recipient,
            code);
    }
}