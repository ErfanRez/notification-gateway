using Notification.Gateway.Presentation.Commands;

namespace Notification.Gateway.Presentation;

internal sealed class CLIWorker : BackgroundService
{
    private readonly ICommandFactory _commandFactory;

    public CLIWorker(
        ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        Console.WriteLine("Mini Notification Gateway");
        Console.WriteLine("Type 'help' for available commands.");
        Console.WriteLine("Press Ctrl+C to exit.");
        Console.WriteLine();

        while (!stoppingToken.IsCancellationRequested)
        {
            Console.Write("> ");

            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            try
            {
                var command = _commandFactory.Create(input);

                await command.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
