namespace Notification.Gateway.Presentation.Commands;

internal interface ICommand
{
    Task ExecuteAsync();
}
