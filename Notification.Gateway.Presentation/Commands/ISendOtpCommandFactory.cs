namespace Notification.Gateway.Presentation.Commands;

internal interface ISendOtpCommandFactory
{
    ICommand Create(
        string recipient,
        string code);
}
