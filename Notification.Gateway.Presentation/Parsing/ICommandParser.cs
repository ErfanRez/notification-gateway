
using Notification.Gateway.Presentation.Commands;

namespace Notification.Gateway.Presentation.Parsing;

internal interface ICommandParser
{
    bool CanParse(string input);

    ICommand CreateCommand(string input);
}
