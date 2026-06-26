using Notification.Gateway.Core;
using Notification.Gateway.Core.Events;
using Notification.Gateway.Presentation;
using Notification.Gateway.Presentation.Commands;
using Notification.Gateway.Presentation.Parsing;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;
services.AddSingleton<ICommandFactory, CommandFactory>();

services.AddSingleton<ISendOtpCommandFactory, SendOtpCommandFactory>();

services.AddSingleton<ICommandParser, HelpCommandParser>();
services.AddSingleton<ICommandParser, SendOtpCommandParser>();
services.AddCore(builder.Configuration);
services.AddHostedService<CLIWorker>();

var host = builder.Build();
host.Services.GetRequiredService<NotificationLogger>();
host.Run();
