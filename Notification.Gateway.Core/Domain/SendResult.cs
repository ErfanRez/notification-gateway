namespace Notification.Gateway.Core.Domain;

public sealed class SendResult
{
    public bool Success { get; init; }

    public string ProviderName { get; init; } = string.Empty;

    public string? ErrorMessage { get; init; }

    public static SendResult Successful(string provider)
        => new()
        {
            Success = true,
            ProviderName = provider
        };

    public static SendResult Failed(string provider, string error)
        => new()
        {
            Success = false,
            ProviderName = provider,
            ErrorMessage = error
        };
}
