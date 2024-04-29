using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace RealEstateBackend.Application
{
    public static class AppServiceConfiguration
    {
        public static IServiceCollection AppConfigureServices(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Information() // Set the minimum log level
               .WriteTo.Console() // Write log events to the console
               .CreateLogger();

            services.AddSingleton(Log.Logger);
            services.AddAutoMapper(typeof(AppServiceConfiguration).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
