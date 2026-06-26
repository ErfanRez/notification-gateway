using Notification.Gateway.Core.Abstractions;

namespace Notification.Gateway.Presentation.Commands;

internal sealed class SendOtpCommand : ICommand
{
    private readonly IMessageFactory _messageFactory;
    private readonly INotificationService _notificationService;

    private readonly string _recipient;
    private readonly string _code;

    public SendOtpCommand(
        IMessageFactory messageFactory,
        INotificationService notificationService,
        string recipient,
        string code)
    {
        _messageFactory = messageFactory;
        _notificationService = notificationService;

        _recipient = recipient;
        _code = code;
    }

    public async Task ExecuteAsync()
    {
        var message = _messageFactory.CreateMessage(
            _recipient,
            _code);

        await _notificationService.SendAsync(message);

        Console.WriteLine();
        Console.WriteLine($"Final Status: {message.Status}");
    }
}
