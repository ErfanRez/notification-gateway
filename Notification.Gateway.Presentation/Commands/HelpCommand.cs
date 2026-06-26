namespace Notification.Gateway.Presentation.Commands;

internal sealed class HelpCommand : ICommand
{
    public Task ExecuteAsync()
    {
        Console.WriteLine();
        Console.WriteLine("Available commands");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("help");
        Console.WriteLine("send -otp -recipient <recipient> -code <code>");
        Console.WriteLine();

        return Task.CompletedTask;
    }
}