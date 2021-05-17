using System;
using System.Threading.Tasks;
using Arbbet.Connectors.Dal.Mappings;
using Arbbet.Connectors.Unibet.Extensions;
using Arbbet.Connectors.Unibet.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace Arbbet.Connectors.Unibet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    var config = new ConfigurationBuilder()
                   .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .Build();

                    Dal.Configuration.ConfigurationExtension.ConfigureDbContext(services);

                    services
                      .AddHttpClient<UnibetService>();

                    services
                      .AddScoped<UnibetJob>()
                      .AddScoped<UnibetService>();

                    Dal.Configuration.ConfigurationExtension.ConfigureDI(services);
                    Domain.Configuration.ConfigurationExtension.ConfigureDI(services);

                    services.AddAutoMapper(typeof(DomainMappingProfile).Assembly);

                    services
                      .AddLogging(loggingBuilder =>
                      {
                          loggingBuilder.ClearProviders();
                          loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                          loggingBuilder.AddNLog(config);
                      });
                })
                .UseConsoleLifetime();

            var host = hostBuilder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myService = services.GetRequiredService<UnibetJob>();
                    var result = await myService.Run();

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }

            //var logger = LogManager.GetCurrentClassLogger();
            //try
            //{
            //    var config = new ConfigurationBuilder()
            //       .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            //       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //       .Build();

            //    var servicesProvider = DependencyInjectionExtensions.BuildDI(config);
            //    using (servicesProvider as IDisposable)
            //    {
            //        var test = new MapperConfiguration(cfg =>
            //        {
            //            cfg.AddProfile(new DomainMappingProfile());
            //        });

            //        var runner = 

            //        Console.WriteLine("Press ANY key to exit");
            //        Console.ReadKey();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // NLog: catch any exception and log it.
            //    logger.Error(ex, "Stopped program because of exception");
            //    throw;
            //}
            //finally
            //{
            //    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            //    LogManager.Shutdown();
            //}
        }
    }
}
