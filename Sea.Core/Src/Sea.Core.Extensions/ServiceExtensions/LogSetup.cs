using Microsoft.Extensions.Hosting;
using Serilog;
namespace Sea.Core.Extensions.ServiceExtensions
{
    public static class LogSetup
    {
        public static IHostBuilder UseLogging(this IHostBuilder builder)
        {
            builder.UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration).Enrich.FromLogContext();
            });

            return builder;
        }
    }
}
