namespace Notification.Gateway.Presentation.Commands;

internal interface ICommandFactory
{
    ICommand Create(string input);
}
