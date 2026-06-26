using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Gateway.Core.Abstractions;
using Notification.Gateway.Core.Events;
using Notification.Gateway.Core.Factories;
using Notification.Gateway.Core.Handlers;
using Notification.Gateway.Core.Providers;
using Notification.Gateway.Core.Services;

namespace Notification.Gateway.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IMessageFactory, OTPMessageFactory>();

        services.AddSingleton<ProviderA>();
        services.AddSingleton<ProviderB>();

        services.AddSingleton<ProviderHandler<ProviderA>>();
        services.AddSingleton<ProviderHandler<ProviderB>>();

        services.AddSingleton<IProviderPipeline, ProviderPipeline>();

        services.AddSingleton<NotificationEventPublisher>();

        services.AddSingleton<NotificationLogger>();

        services.AddSingleton<INotificationService, NotificationService>();

        return services;
    }
}
