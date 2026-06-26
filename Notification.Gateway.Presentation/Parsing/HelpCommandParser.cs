using Notification.Gateway.Presentation.Commands;

namespace Notification.Gateway.Presentation.Parsing;

internal sealed class HelpCommandParser : ICommandParser
{
    public bool CanParse(string input)
    {
        return input.Equals(
            "help",
            StringComparison.OrdinalIgnoreCase);
    }

    public ICommand CreateCommand(string input)
    {
        return new HelpCommand();
    }
}