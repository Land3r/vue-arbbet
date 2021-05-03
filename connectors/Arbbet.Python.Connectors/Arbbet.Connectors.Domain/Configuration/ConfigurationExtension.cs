using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Connectors.Domain.Statistics;

using Microsoft.Extensions.DependencyInjection;

namespace Arbbet.Connectors.Domain.Configuration
{
  public static class ConfigurationExtension
  {
    public static IServiceCollection ConfigureDI(IServiceCollection services)
    {
      return services
        .AddTransient<MonitoredScope>()
        .AddSingleton<PerformanceStatService>()
        .AddSingleton<StatisticService>();
    }
  }
}
