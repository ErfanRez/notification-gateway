using Notification.Gateway.Presentation.Commands;

namespace Notification.Gateway.Presentation.Parsing;

internal sealed class CommandFactory : ICommandFactory
{
    private readonly IEnumerable<ICommandParser> _parsers;

    public CommandFactory(
        IEnumerable<ICommandParser> parsers)
    {
        _parsers = parsers;
    }

    public ICommand Create(string input)
    {
        var parser = _parsers.FirstOrDefault(
            x => x.CanParse(input));

        return parser?.CreateCommand(input)
               ?? new UnknownCommand();
    }
}