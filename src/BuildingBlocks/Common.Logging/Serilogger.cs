using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.Logging;

public static class Serilogger
{
    public static Action<HostBuilderContext, LoggerConfiguration> Configuration =>
        (context, configuration) =>
        {
            var applicationName = context.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-") ?? "unknown";
            var environmentName = context.HostingEnvironment.EnvironmentName?.ToLower() ?? "Development";

            configuration
                .WriteTo.Debug()
                .WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("ApplicationName", applicationName)
                .Enrich.WithProperty("EnvironmentName", environmentName)
                .ReadFrom.Configuration(context.Configuration);
        };
}