using System;
using System.Threading.Tasks;

using Arbbet.Connectors.Unibet.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

using NLog;

namespace Arbbet.Connectors.Unibet
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var logger = LogManager.GetCurrentClassLogger();
      try
      {
        var config = new ConfigurationBuilder()
           .SetBasePath(System.IO.Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

        var servicesProvider = DependencyInjectionExtensions.BuildDI(config);
        using (servicesProvider as IDisposable)
        {
          var runner = servicesProvider.GetRequiredService<UnibetJob>();
          await runner.Run();

          Console.WriteLine("Press ANY key to exit");
          Console.ReadKey();
        }
      }
      catch (Exception ex)
      {
        // NLog: catch any exception and log it.
        logger.Error(ex, "Stopped program because of exception");
        throw;
      }
      finally
      {
        // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
        LogManager.Shutdown();
      }
    }
  }
}
