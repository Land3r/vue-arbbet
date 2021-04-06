using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Dal.Configuration;
using Arbbet.Connectors.Unibet.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using NLog.Extensions.Logging;

namespace Arbbet.Connectors.Unibet.Extensions
{
  public static class DependencyInjectionExtensions
  {
    public static IServiceProvider BuildDI(IConfiguration config)
    {
      var services = new ServiceCollection();

      Dal.Configuration.ConfigurationExtension.ConfigureDbContext(services);

      services
        .AddHttpClient<UnibetService>();

      services
        .AddScoped<UnibetJob>()
        .AddScoped<UnibetService>();

      Dal.Configuration.ConfigurationExtension.ConfigureDI(services);
      Domain.Configuration.ConfigurationExtension.ConfigureDI(services);

      services
        .AddLogging(loggingBuilder =>
        {
          loggingBuilder.ClearProviders();
          loggingBuilder.SetMinimumLevel(LogLevel.Trace);
          loggingBuilder.AddNLog(config);
        });
        

      return services.BuildServiceProvider();
    }
  }
}
