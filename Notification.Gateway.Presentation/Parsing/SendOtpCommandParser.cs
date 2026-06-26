using Notification.Gateway.Presentation.Commands;

namespace Notification.Gateway.Presentation.Parsing;

internal sealed class SendOtpCommandParser : ICommandParser
{
    private readonly ISendOtpCommandFactory _factory;

    public SendOtpCommandParser(
        ISendOtpCommandFactory factory)
    {
        _factory = factory;
    }

    public bool CanParse(string input)
    {
        return input.StartsWith(
            "send",
            StringComparison.OrdinalIgnoreCase);
    }

    public ICommand CreateCommand(string input)
    {
        var args = input.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries |
            StringSplitOptions.TrimEntries);

        if (!args.Contains("-otp"))
            return new UnknownCommand();

        var recipient = GetOption(args, "-recipient");
        var code = GetOption(args, "-code");

        if (recipient is null || code is null)
            return new UnknownCommand();

        return _factory.Create(
            recipient,
            code);
    }

    private static string? GetOption(
        string[] args,
        string option)
    {
        var index = Array.IndexOf(args, option);

        if (index < 0)
            return null;

        if (index + 1 >= args.Length)
            return null;

        return args[index + 1];
    }
}