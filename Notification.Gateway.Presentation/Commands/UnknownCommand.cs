namespace Notification.Gateway.Presentation.Commands;

internal sealed class UnknownCommand : ICommand
{
    public Task ExecuteAsync()
    {
        Console.WriteLine("Unknown command.");
        Console.WriteLine("Type 'help'.");

        return Task.CompletedTask;
    }
}