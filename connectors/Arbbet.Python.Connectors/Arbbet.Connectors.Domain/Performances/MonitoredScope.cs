using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Domain.Performances
{
  public class MonitoredScope : IDisposable
  {
    private readonly PerformanceStatService _performanceStatService;
    private readonly Stopwatch _watch;

    public MonitoredScopeType? Type { get; set; }

    public string Name { get; set; }

    public MonitoredScope(PerformanceStatService performanceStatService)
    {
      _performanceStatService = performanceStatService;

      _watch = new Stopwatch();
      _watch.Start();
    }

    public void Dispose()
    {
      _watch.Stop();
      _performanceStatService.AddStat(new PerformanceStat()
      {
        Name = this.Name,
        Type = this.Type,
        TimeElapsed = _watch.ElapsedMilliseconds
      });
    }
  }

  public enum MonitoredScopeType
  {
    Unknown,
    Processing,
    Network,
    Database
  }
}
